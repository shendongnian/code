    if (Session.Count > 0)
    {
    if (Session["username"] != null)
    {
                string name = (string)Session["userFName"];
                txtGreeting.Visible = true;
                txtGreeting.Text = "Welcome " + name + " , you are logged in! ";
    }
    else{
    Response.Redirect(Logout.aspx);
    }
    }
