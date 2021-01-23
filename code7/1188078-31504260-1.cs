    public class CreateNiagaModel : IValidatableObject
    {
        [DisplayName("Merchant Name : ")]
        [Required]
        [MaxLength(20)]
        public string merchant { get; set; }
        [DisplayName("Merchant Description : ")]
        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(250)]
        public string merchant_desc { get; set; }
        [DisplayName("Seller Type : ")]
        [Required]
        public string sellerType { get; set;
        [DisplayName("ROC : ")]               
        public string roc{ get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext ctx)
        {
            if (sellerType == "company" && string.IsNullOrEmpty(roc))
            {
                yield return new ValidationResult("ROC is required when seller type is Company", new[] { "roc" });
            }
        }
    }
