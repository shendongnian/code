    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Configuration;
    using System.Data.SqlClient;
    
    namespace FinalYearProject
    {
        public partial class MBooking : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    this.BindGrid();
                }
            }
    
            private void BindGrid()
            {
                string constr = ConfigurationManager.ConnectionStrings["cmt"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Customers_CRUD"))
                    {
                        cmd.Parameters.AddWithValue("@Action", "SELECT");
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
    
            protected void Insert(object sender, EventArgs e)
            {
                string Username = txtUsername.Text;
                string Provincename = txtProvinceName.Text;
                string Cityname = txtCityname.Text;
                string Number = txtNumber.Text;
                string Name = txtName.Text;
                string ContentType = txtContentType.Text;
                string Data = txtData.Text;
    
    
                string constr = ConfigurationManager.ConnectionStrings["cmt"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Customers_CRUD"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "INSERT");
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Provincename ", Provincename);
                        cmd.Parameters.AddWithValue("@Cityname", Cityname);
                        cmd.Parameters.AddWithValue("@Number", Number);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@ContentType", ContentType);
                        //cmd.Parameters.AddWithValue("@Data", Data);
                        cmd.Parameters.AddWithValue("@Data", SqlDbType.VarBinary).Value = new Byte[] { 0xDE, 0xAD, 0xBE, 0xEF };
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                this.BindGrid();
            }
    
            protected void OnRowEditing(object sender, GridViewEditEventArgs e)
            {
                GridView1.EditIndex = e.NewEditIndex;
                this.BindGrid();
            }
    
            protected void OnRowCancelingEdit(object sender, EventArgs e)
            {
                GridView1.EditIndex = -1;
                this.BindGrid();
            }
    
            protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int BId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string Username = (row.FindControl("txtUserName") as TextBox).Text;
                string Provincename = (row.FindControl("txtProvincename") as TextBox).Text;
                string Cityname = (row.FindControl("txtCityname") as TextBox).Text;
                string Number = (row.FindControl("txtNumber") as TextBox).Text;
                string Name = (row.FindControl("txtName") as TextBox).Text;
                string ContentType = (row.FindControl("txtContentType") as TextBox).Text;
                string Data = (row.FindControl("txtData") as TextBox).Text;
                string constr = ConfigurationManager.ConnectionStrings["cmt"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Customers_CRUD"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "UPDATE");
                        cmd.Parameters.AddWithValue("@BId", BId);
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Provincename ", Provincename);
                        cmd.Parameters.AddWithValue("@Cityname", Cityname);
                        cmd.Parameters.AddWithValue("@Number", Number);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@ContentType",ContentType) ;
                        cmd.Parameters.AddWithValue("@Data", SqlDbType.VarBinary).Value = new Byte[] { 0xDE, 0xAD, 0xBE, 0xEF };
                        //cmd.Parameters.AddWithValue("@ContentType", SqlDbType.VarBinary, -1);
                        //cmd.Parameters.AddWithValue("@Data", SqlDbType.VarBinary, -1);
                       
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                GridView1.EditIndex = -1;
                this.BindGrid();
            }
            protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                GridView1.PageIndex = e.NewPageIndex;
                this.BindGrid();
            }
    
            protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
            {
                //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
                //{
                //    (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
                //}
            }
            protected void DownloadFile(object sender, EventArgs e)
            {
                int id = int.Parse((sender as LinkButton).CommandArgument);
                byte[] bytes;
                string fileName, contentType;
                string constr = ConfigurationManager.ConnectionStrings["cmt"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select Name, Data, ContentType from tblbooking where BId=@BId";
                        cmd.Parameters.AddWithValue("@BId",id);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["Name"].ToString();
                        }
                        con.Close();
                    }
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
    
            protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                int BId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string constr = ConfigurationManager.ConnectionStrings["cmt"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Customers_CRUD"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "DELETE");
                        cmd.Parameters.AddWithValue("@BId", BId);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                this.BindGrid();
            }
        }
    }
