    public class AccountCompanyRole
    {
        [Key, Column(Order = 0)]
        public int AccountID { get; set; }
    
        [Key, Column(Order = 1)]
        public int CompanyID { get; set; }
    
        [Key, Column(Order = 2), ForeignKey("Role")]
        public int RoleID { get; set; }
    
        [ForeignKey("AccountID, CompanyID")]
        public virtual AccountCompany AccountCompany { get; set; }
    
        public virtual Role Role { get; set; }
    }
