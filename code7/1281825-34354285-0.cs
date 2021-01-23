    public class PasswordResetModel 
    {
        public bool PasswordCreationStatus { get; set; }
    
        [Display(Name = "AcctNumber", ResourceType = typeof(Resources.Register))]        
        //Account number is numeric
        [RegularExpression(@"^[0-9]+$", ErrorMessageResourceType = typeof(Resources.Register),
          ErrorMessageResourceName = "AccountNumberRegularExpr")]
        [ScriptIgnore]
        public int? AccountNumber { get; set; }
    
        [Display(Name = "BirthDate", ResourceType = typeof(Resources.Register))]        
        [ScriptIgnore]
        public string BirthDate { get; set; }
    
        [Display(Name = "SSN", ResourceType = typeof(Resources.Register))]      
        //Accepts only four digits
        [RegularExpression(@"^\d{4}$", ErrorMessageResourceType = typeof(Resources.Register),ErrorMessageResourceName = "SSNRegularExpr")]
        [StringLength(4, ErrorMessageResourceType = typeof(Resources.Register),ErrorMessageResourceName = "SSNRegularExpr")]
        [ScriptIgnore]
        public string SSN { get; set; }
        [Required(ErrorMessage = "Must Have At Least One of the properties")]
        public string MustHaveAtLeastOneIsValid {
           get{
               return  this.SSN != null || this.BirthDate != null || this.AccountNumber.HasValue ? "valid": null;
           }
        }
    }
