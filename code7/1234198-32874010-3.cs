        public string LastName { get; set; }
        public string FirstName { get; set; }
        [NotMapped] //This will make sure that entity framework will not map this to a new column
        public string FullName
        {
            get { return LastName + " " + FirstName; }
            // Here comes your desired setter method.
            set
            {
                string[] str = value.Split(' ');
                if (str.Length == 2)
                {
                    FirstName = str[1];
                    LastName = str[0];
                }
                else if (str.Length >= 0 && value.Length > 0)
                {
                    LastName = str[0];
                }
                else
                    throw new Exception("Invalid name");
            }
        }
