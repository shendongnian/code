        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentNullException("Must Include Last Name");
                }
                lastName = value;
            }
        }
