    @model sample.Models.LoginViewModel
        
        @{
           if(Session["users"] != null)
           {
            string user = Session["users"].ToString();
           } 
        }
        @{
            ViewBag.Title = "Home Page";  
        }
