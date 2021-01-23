        public string this[string columnName]
        {
            get
            {
                var validator = new StsInfoValidator();
                if (columnName.Equals("SomeProperty"))
                {
                    // SomeProperty below is null
                    //option 1
                    var result  = validator.Validate(this,s => s.SomeProperty);
                    //option 2
                    //var result  = validator.Validate(this, columnName);
                    //option 3
                    //var result  = validator.Validate(this, "SomeProperty");
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
