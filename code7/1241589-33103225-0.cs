    class Employee{
        public String FirstName { get; }
            public String LastName { get; }
            public String FullName {
                get{
                    return String.Format("{0}, {1}", FirstName, LastName);
                }
            }
        }
    }
