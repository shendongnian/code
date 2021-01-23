        [EqualsToText(new[] { "Active", "Termination" })]
        public string TestString
        {
            get
            {
                return this.testString;
            }
            set
            {
                //This is to test the validation. Can be removed if you are using the control which applies Validation attributes automatically, e.g. DataGrid
                Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "TestString" }); 
                this.testString = value;
            }
        }
