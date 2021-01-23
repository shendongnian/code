    namespace IncendoVentures
 
            if (Session["New"] != null)
            {
                Label_welcome.Text += Session["New"].ToString();
            }
            else
                Response.Redirect("MainPage.aspx");
            if (!IsPostBack)
            {
                Session["username"] = 1;
            }
           
        }
        protected void GridView1_RowCommand(object sender, EventArgs e)
        {
            Response.Redirect("Uploads.aspx");
        }
        
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
