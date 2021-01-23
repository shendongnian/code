    public class Ticket : IDataErrorInfo
    {
        [Required(ErrorMessage = "This field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Only Int")]
        public int? Tic_Id { get; set; }
    
        [Required(ErrorMessage = "This field is required")]
        public DateTime? Tic_Date { get; set; }
    
        string IDataErrorInfo.Error
        {
            get
            {
                /* It can be improved */		
                return String.Empty;
            }
        }
    
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                Type objectType = GetType();
                PropertyInfo propertyInfo = objectType.GetProperty(propertyName);
                object propertyValue = propertyInfo.GetValue(this, null);
                List<System.ComponentModel.DataAnnotations.ValidationResult> results 
                    = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
    
                ValidationContext validationContext = 
                    new System.ComponentModel.DataAnnotations.ValidationContext(this, null, null);
                validationContext.MemberName = propertyName;
    
                return Validator.TryValidateProperty(propertyValue, validationContext, results) ?
                    String.Empty : results[0].ErrorMessage;
            }
        }
    }
