    public class OrganizationUserSignedByVM
    {
        public int? ID { get; set; } // so you can use it in an edit view as well
        [Display(Name = "Bank")]
        [Required(ErrorMesage = "Please select a bank")]
        public int SelectedBank { get; set; }
        public SelectList BankList { get; set; }
        .....
    }
