         public class CustomerEntity : TableEntity
         {
                public CustomerEntity() { }
                public CustomerEntity(string lastName, string firstName)
                {
                    this.PartitionKey = lastName;
                    this.RowKey = firstName;
                }
    
                public string Email { get; set; }
                public string CellPhoneNumber { get; set; }
    
                public string Optional1 { get; set; }
                public string Optional2 { get; set; }    
            }
        }
