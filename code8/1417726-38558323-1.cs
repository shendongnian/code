    public class CustomerVM
    {
        [Display(Name = "Customer Id")]
        [Required(ErrorMesage = "Please enter the customer id")]
        public int? Id { get; set; }
        [Display(Name = "Customer Code")]
        [Required(ErrorMesage = "Please enter the customer code")]
        public string Code { get; set; }
        [Display(Name = "Customer Amount")]
        [Required(ErrorMesage = "Please enter the customer amount")]
        public double? Amount { get; set; }
    }
