        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Color
            {
                get
                {
                    if (this.FirstName.StartsWith("fr", StringComparison.OrdinalIgnoreCase))
                        return "red";
                    else if (this.FirstName.ToLower().Contains("jeff"))
                        return "green";
                    else if (this.LastName.ToLower() == "smith")
                        return "blue";
                    return "black";
                }
            }
        }
