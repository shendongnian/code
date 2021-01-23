    public class Customer
        {
            public int CustomerId {get;set;}
            public string FirstName {get;set;}
            public string LastName {get;set;}
            public string Email {get;set;}
        
            public bool Empty
            {
                get { return (CustomerId == 0 && 
                              string.IsNullOrWhiteSpace(FirstName) &&
                              string.IsNullOrWhiteSpace(LastName) &&
                              string.IsNullOrWhiteSpace(Email));
                    }
            }
        }
