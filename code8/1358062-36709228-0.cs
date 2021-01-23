     namespace Tester.Models
    {
        public class EMPLOYEEVIEWMODEL
        {
            public int EmpID { get; set; }
            public string EmpName { get; set; }
            public int Rank { get; set; }
            public ADDRESSVIEWMODEL Address { get; set; }
            public STOREVIEWMODEL Store { get; set; }
    
        }
    
        public class STOREVIEWMODEL
        {
            public int StoreID { get; set; }
            public string BranchName { get; set; }       
        }
        public class ADDRESSVIEWMODEL
        {
            public int AddId { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }        
        }
    
    }
