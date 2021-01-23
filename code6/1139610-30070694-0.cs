    class ValidationEntity : ValidationRule
    {
       public string Key { get; set; }
             
       public string BaseName = "QCS";
             
       public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
       {
           var fullPropertyName = BaseName + "." + Key;
           ValidationEntry entry;
             
           var validationResult = new ValidationResult(true, null);
             
           if ((entry = ValidationManager.Instance.FindValidation(fullPropertyName)) != null)
           {
               int errorNumber;
               string errorString;
             
               var strValue = (value != null) ? value.ToString() : string.Empty;
             
               if (entry.Validate(strValue, out errorNumber, out errorString) == false)
               {
                   validationResult = new ValidationResult(false, errorString);
               }
           }
             
           if (OnValidationChanged != null)
           {
               OnValidationChanged(Key, validationResult);
           }
           return validationResult;
       }
             
       public event Action<string, ValidationResult> OnValidationChanged;
    }
