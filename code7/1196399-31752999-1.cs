    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace gridViewDeals
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    SqlConnection con = new SqlConnection("Data Source=HAMMADMAQBOOL;Initial Catalog=ModulesDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("Select * From GVDemo", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
    
    
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;
    
                if (gvr.RowType == DataControlRowType.DataRow)
                {
                    string Namme = (gvr.FindControl("LabelName") as Label).Text;
                    //Write Query here to Delete Data. . . 
                    //Call Functon Here to Delete the Image From Folder. . . 
                }
    
            }
    
           
        }
    }
