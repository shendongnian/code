    using System.ComponentModel;
    class ViewModel, IDataErrorInfo
    {
        public string Name {get;set;}
        private bool formContainsErrors;
        private string formError;
        private AlphanumericValidationRule alphanumericValidation;
        public ViewModel()
        {
            this.alphanumericValidation = new AlphanumericValidationRule();
            this.formContainsErrors = false;
        }
        public string Error
        {
            get { return this.formError; }
        }
        public string this[string columnName]
        {
            get
            {
                this.formError = null;
                switch (columnName)
                {
                    case "Name":
                        this.formError = (string)this.alphanumericValidation.Validate(this.Name, null).ErrorContent;
                        break;
                }
                this.formContainsErrors = (this.formError != null);
                return this.formError;
            }
        }
    }
