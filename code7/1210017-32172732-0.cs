            public CustomerEntity(string lastName, string firstName)
            {
                this.PartitionKey = lastName;
                this.RowKey = firstName;
            }
            public CustomerEntity() { }
            public string Email { get; set; }
            public string cellPhoneNumber { get; set; }
            public string optional1 { get; set; }
            public string optional2 { get; set; }
          }
