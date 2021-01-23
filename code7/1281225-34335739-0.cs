        public class EmployeeInfo
        {
            private string employeeName;
            public string EmployeeName 
            {
               get
               {
                    return employeeName ?? ""; //Returns the content, or an empty string if it is null
               } 
               set
               {
                     employeeName = value;
               }
           }
        
        }
