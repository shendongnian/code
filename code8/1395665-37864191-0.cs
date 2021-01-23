      public class Account
            {
                // One to one to one relationship (shared PK)
                public int Id { get; set; }
    
                // One to one to one relationship (shared PK)
                public virtual Operation Operation { get; set; }
    
                // One to many relationship foreign Key
                [InverseProperty("AccountForList")]
                public virtual List<Operation> Operations { get; set; }
            }
    
            public class Operation
            {
                // One to one to one relationship (shared PK)
                [ForeignKey("Account")]
                public Int32 Id { get; set; }
    
                // One to one to one relationship (shared PK)
                public virtual Account Account { get; set; }
    
                // One to many relationship foreign Key
                public Int32? AccountForListId { get; set; }
    
                // One to many relationship foreign Key
                [ForeignKey("AccountForListId")]
                public virtual Account AccountForList { get; set; }
            }
