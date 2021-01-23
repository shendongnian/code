            public ActionResult Login(FormCollection form)
            {
                //first, your logic to log user in
                
                //if credentials match, then store them into the Session
                Session["username"] = form["USERNAME"].ToString();
                Session["password"] = form["pasword"].ToString();
    
                
            }
    
            //to access the data from some other action, write:
            public ActionResult anyAction()
            {
                string username = Session["username"].ToString();
                string password = Session["password"].ToString();
    
                //and then do whatever you wanna do with them
            }
