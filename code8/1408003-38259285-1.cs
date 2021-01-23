    public class PaymentInformationModel
        {
            [Display(Name = "Payment Amount")]
            [Required(ErrorMessage = "Please enter the {0}")]
            //[MaxLength(9)]
            [RegularExpression(@"^\d+.\d{0,2}$")]
            [Range(0, 9999999999999999.99)]
            public decimal PaymentAmount { get; set; }
        }
