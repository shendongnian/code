    public class PaymentViewModel
    {
    
        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
    
        public string CardName { get; set; }
        // ------------------------------Visa Card ---------------------------------------------//
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})|(4903|4905|4911|4936|6333|6759)[0-9]{12}|(4903|4905|4911|4936|6333|6759)[0-9]{14}|(4903|4905|4911|4936|6333|6759)[0-9]{15}|564182[0-9]{10}|564182[0-9]{12}|564182[0-9]{13}|633110[0-9]{10}|633110[0-9]{12}|633110[0-9]{13}$", ErrorMessage = "Invalid Card Number You Paki")]
    
    
        public string CardNumber { get; set; }
        [Display(Name = "Valid From"), DataType(DataType.Date) DisplayFormat(DataFormatString = "{0:MM}")]
        public DateTime ValidFrom { get; set; }
        [Display(Name = "Valid From"), DataType(DataType.Date) DisplayFormat(DataFormatString = "{0:MM}")]
        public DateTime Expires { get; set; }
        public string CardSecurityCode { get; set; }
    
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Compare("EmailAddress", ErrorMessage = "The email and confirmation email do not match.")]
    
        public string ConfrimEmailAddress { get; set; }
        [RegularExpression(@"([a-zA-Z0-9\s]+)", ErrorMessage = "Invalid Address")]
    
        public string Address { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string City { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Country { get; set; }
        [RegularExpression(@"\b\d{5}(?:-\d{4})?\b+", ErrorMessage = "Invalid postcode")]
        public string PostCode { get; set; }
    }
