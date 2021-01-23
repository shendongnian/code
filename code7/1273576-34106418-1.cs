        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();
        public string this[string columnName]
        {
            get
            {
                string errorMessage = null;
                if (errors.TryGetValue(columnName, errorMessage) 
                {
                    return errorMessage;
                }
                return null;
            }
        }
        protected void AddErrorMessage(string columnName, string errorMessage) 
        {
            errors[columnName] = errorMessage;
        }
        protected void RemoveErrorMessage(string columnName) 
        {
             if(errors.ContainsKey(columnName)) 
            {
                errors.Remove(columnName);
            }
        }
        protected virtual void Validate() 
        {
                errors.Clear();
                if (this.IntegerGreater10Property < 10)
                {
                    this.AddErrorMessage("IntegerGreater10Property", "Number is not greater than 10!");
                }
                if (this.DatePickerDate == null)
                {
                    this.AddErrorMessage("DatePickerDate", "No Date given!");
                }
                if (string.IsNullOrEmpty(FirstName) || FirstName.Length < 3)
                {
                    this.AddErrorMessage("FirstName", "Please Enter  First Name");
                }
                if (string.IsNullOrEmpty(LastName) || Lastname.Length < 3)
                {
                    this.AddErrorMessage("LastName", "Please Enter Last Name");
                }
        }
