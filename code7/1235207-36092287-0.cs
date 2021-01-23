        public class Client
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Number { get; set; }
        }
        public class Department 
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ClientId { get; set; }
            public virtual Client Client { get; set; }
            [NotMapped]
            public int? ClientNumber {
                get {
                    return Client != null ? Client.Number : null;
                }
            }
        }
