    protected void Page_Load(object sender, EventArgs e)
        {
             
                 FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                 FormsAuthenticationTicket ticket = id.Ticket;
                 string userData = ticket.UserData;
                 string[] temp = userData.Split(',');
                 role=temp[0];
             if (role!="Owner")
             {
                 Response.Write("............");
             }
        }
