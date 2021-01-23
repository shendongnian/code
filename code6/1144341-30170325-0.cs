     protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string name=string.Format("{0}",Request.Form["username"]);
            string pass = string.Format("{0}", Request.Form["password"]);
    
            int userId;
            userId = LoginService.GetUserId(name, pass, 0, 1);
    
            if (userId == 0)
            {
                MessageBoxShow(Page, "UserName does not exists.");
    
            }
            else
            {
                MessageBoxShow(Page, "You are successfully connected.");
                Session["userId"] = userId.ToString();
                SalService.DeleteFromSal();
            }
        }
    
    }
