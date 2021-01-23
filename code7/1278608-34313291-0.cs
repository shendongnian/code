            public ActionResult Login(FormCollection form)
            {
                Session["username"] = form["USERNAME"].ToString();
                Session["password"] = form["password"].ToString();
    
                //and then your logic to log user in
            }
    
            //to access the data from some other action, write:
            public ActionResult anyAction()
            {
                string username = Session["username"].ToString();
                string password = Session["password"].ToString();
    
                //and then do whatever you wanna do with them
            }
