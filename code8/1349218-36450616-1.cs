    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Web;  
    using System.ComponentModel.DataAnnotations;  
      
    namespace Custom_DataAnnotation_Attribute.Models  
    {  
        public class EmployeeModel  
        {  
            public string Name { get; set; }  
      
            [CustomEmailValidator]  
            public string Email { get; set; }  
            public string Password { get; set; }  
            public string Mobile { get; set; }          
        }  
    }  
