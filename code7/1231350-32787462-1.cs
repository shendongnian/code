    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using MSSQLConnector;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace SoftwareAnalysisAndDesign.SAD
    {
        public partial class AdministratorPage : System.Web.UI.Page
        {
 
           protected void Page_Load(object sender, EventArgs e)
            {
                //If session is null, go to login page
                if (Session["adminlogin"] == null)
                {
                    Response.Redirect("LoginPage.aspx", true);
                }
            }
        }
    }
