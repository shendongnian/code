    // CONTROLLER
    public void CarAJAX()
    {
        CarAdmin CA = new CarAdmin();
        CA.HTML_Stuff = Request.Form["HTML_Stuff"];
        CA.UpdateCar();
    }
    
    // MODEL
    using System;
    using System.Web;
    using System.Web.Mvc;
    
    namespace Site.Models
    {
        public class CarAdmin
        {
            private string html;
            
            public String id { get; set; }
            [AllowHtml]
            public String HTML_Stuff { 
                get
                { 
                    return html; 
                }
                set
                { 
                    // sanitation and validation on "value"
                    html = value;
                }
            }
    
            public CarAdmin(){}
    
            public void UpdateCar()
            {
                String Select = String.Format("UPDATE Car Set HTML_Stuff = {0} WHERE id = {1}", HTML_Stuff, id);
    
                // Execute DB Command
            }
        }
    }
