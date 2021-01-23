            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string FullName
            {
                get { return LastName + " " + FirstName; }
                // Here comes your desired setter method.
                set
                {
                    string[] str = value.Split(' ');
                    if (str.Length >= 2)
                    {
                        FirstName = str[1];
                        LastName = str[0];
                    }
                }
            }
