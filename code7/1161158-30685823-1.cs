    public string FirstName
    {
        get { return firstName; }
        private set
        {
            // Here you must check if value is not null or empty, not the field
            if (string.IsNullOrWhiteSpace(value)){
                throw new ArgumentNullException("Must Include First Name");
            }
            this.firstName = value;
        }
    }
