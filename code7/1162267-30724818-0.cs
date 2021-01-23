    public class EntityBase : IDataErrorInfo
    {
        public virtual bool IsValid()
        {
            return GetValidationErrors() == string.Empty;
        }
        protected virtual string GetValidationErrors()
        {
            var vc = new ValidationContext(this, null, null);
            var vResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(this, vc, vResults, true))
                return vResults.Aggregate("", (current, ve) => current + (ve.ErrorMessage + Environment.NewLine));
            return "";
        }
        
        protected virtual string GetValidationErrors(string columnName)
        {
            var vc = new ValidationContext(this, null, null);
            var vResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(this, vc, vResults, true))
            {
                string error = "";
                foreach (var ve in vResults)
                {
                    if (ve.MemberNames.Contains(columnName, StringComparer.CurrentCultureIgnoreCase))
                        error += ve.ErrorMessage + Environment.NewLine;
                }
                return error;
            }
            return "";
        }
        string IDataErrorInfo.Error
        {
            get { return GetValidationErrors(); }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get { return GetValidationErrors(columnName); }
        }
    }
