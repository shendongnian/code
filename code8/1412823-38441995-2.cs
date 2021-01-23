    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Configuration;
    using System.Data;
    using System.IO;
    using System.Data.SqlClient;
    
    namespace DB_Test1
    {
        public partial class Search_Results_1 : System.Web.UI.Page
        {
            string b;
            Object o;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Request.QueryString["Search"] != null)
                {
                    if (Request.QueryString["Text"] != null)
                    {
                        string a = Request.QueryString["Text"];
                        b = a;
                        recipeSearch(a);
                    }
                }
            }
            protected void recipeSearch(string a)
            {
                //Search the database
                con.Open();
                try
                {
                    SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Recipes WHERE Type LIKE '%" + a + "%'", con);
                    DataTable dt = new DataTable();
    
                    adp.Fill(dt);
    
                    if (dt.Rows.Count > 0)
                    {
                        FormViewRecipes.DataSource = dt;
                        FormViewRecipes.DataBind();
                        //lblDataTable.Text = dt.Rows.Count.ToString(); ---Used for testing-
                        o = dt.Rows[0]["RecipeId"];
                       
                    }
                    else
                    {
                        FormViewRecipes.DataSource = null;
                        FormViewRecipes.DataBind();
                    }
                }
                
                catch (Exception ex)
                {
                    //throw new ApplicationException("operation failed!", ex);
                }
                con.Close();
                FormViewRecipes.Visible = true;
    
                string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("RETRIEVE_RECIPE", con);
                    cmd.CommandType = CommandType.StoredProcedure;
    
                    SqlParameter paramId = new SqlParameter()
                    {
                        ParameterName = "@RecipeId",
                        Value = o //Object from the datatable
    
                };
                    cmd.Parameters.Add(paramId);
                    con.Open();
                    byte[] bytes = (byte[])cmd.ExecuteScalar();
    
                    if (bytes != null)
                    {
                        string strBase64 = Convert.ToBase64String(bytes);
                        Image1.ImageUrl = "data:Image/png;base64," + strBase64;
                    }
                    else
                    {
                        Image1.ImageUrl = "~/images/NoImageAvail.jpg";
                    }
                }
    
                Image1.Visible = true;
                
    
            }
            protected void FormViewRecipes_PageIndexChanging(object sender, FormViewPageEventArgs e)
            {
                string a = b;
                FormViewRecipes.PageIndex = e.NewPageIndex;
                recipeSearch(a);
            }
        }
    }
