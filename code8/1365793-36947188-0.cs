    using System.Collections.Generic;
    
    namespace dBudget.Models {
    
        public class Movement {
            public int Id { get; set; }
            public double Value { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public System.DateTime Date { get; set; }
    
            public List<Account> Accounts { get; set; }
        }
    
        public partial class Account {
            public double Balance { get; set; }
            public virtual ICollection<Movement> Movements { get; set; }
        }
    }
