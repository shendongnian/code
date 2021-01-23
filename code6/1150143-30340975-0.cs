    @model sample.Models.LoginViewModel
        
        @{
            string user = Session["users"].ToString();
        }
        @{
            ViewBag.Title = "Home Page";  
        }
