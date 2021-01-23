    public partial class validAccountStatus
    {
        [Key]
        public int AccountStatusID { get; set; }
        [Display(Name = "Account Status")]
        public string AccountStatus { get; set; }
    
        public virtual List<Account> Accounts { get; set; }
    }
