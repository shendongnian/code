    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace YourProject.Models
    {
        public class YourViewModel
        {
            public YourViewModel()
            {
               
                 //This is the constructor of the class
                //Call the function you need
               var tVar = Helpers.CommonFunctions.GenerateSHA("String to process");
      
            }
        }
    }
