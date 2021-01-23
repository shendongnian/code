    public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(this.firstName)){
                    throw new ArgumentNullException("Must Include First Name");
                }
                this.firstName = value;
            }
        }
