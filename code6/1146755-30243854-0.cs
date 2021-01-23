    public class MyDetails
        {
            private string firstName;
            public string FirstName
            {
                get { return firstName; }
                set
                {
                    firstName = value;
                    OnPropertyChange("FirstName");
                }
            }
    
            private string lastName;
            public string LastName
            {
                get { return lastName; }
                set
                {
                    lastName = value;
                    OnPropertyChange("LastName");
                }
            }
        }
