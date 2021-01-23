validator.Validate(this, columnName);
        public string this[string columnName]
        {
            get
            {
                var validator = new StsInfoValidator();
                if (columnName.Equals("SomeProperty"))
                {
                    // SomeProperty below is null
                    var result  = validator.Validate(this,s => s.SomeProperty);
                    if (result.Errors.Any())
                        return validator.Validate(this, CampusNexusApiServer).Errors.FirstOrDefault().ErrorMessage;
                    else
                    {
                        validator = null;
                        return string.Empty;
                    }
                }
                return string.Empty;
            }
        }
