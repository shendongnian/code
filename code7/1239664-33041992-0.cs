    public partial class Account
    {
       public int AccountID { get; set; }
       [Display(Name = "Account Status ID")]
       public Nullable<int> AccountStatusID { get; set; }
       /* HERE */       
       [ForeignKey("AccountStatusID")] 
       public virtual validAccountStatus validAccountStatus { get; set; }
    }
