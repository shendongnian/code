    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using MSSQLConnector;
    using System.Data;
    
    namespace SoftwareAnalysisAndDesign.SAD
    {
        public partial class LoginPage: System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                //If session is not null  redirect to this page
                if (Session["adminlogin"] != null)
                {
                    Response.Redirect("AdministratorPage.aspx", true);
                }
            }
            public void Admin()
            {
                //String decleration
                string adminusername = (this.UserName.Value);
                string adminpass = (this.Password.Value);
    
                try
                {
                    if (adminusername == "admin" && adminpass == "cmpe1234")
                    {
                        Session["adminlogin"] = adminusername;
                        Response.Redirect("AdministratorPage.aspx");
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Username and password does not match. Try again');</script>");
                    }
                }
                catch
                {
                    Response.Write("<script language=javascript>alert('Username and password does not match. Try again');</script>");
                }
            }
        }
    }
