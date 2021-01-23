      public class users
            {        
                public string name{ get; set; }
            }
            
            // in your controller code
            ViewData["list"] = new List<users>(new users[] { new users() 
                              { name="prasad"}, new users() {name="raja"}});
