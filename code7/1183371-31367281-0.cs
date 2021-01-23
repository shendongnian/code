    public class AccountEmail {
        public long AccountID {get;set;}
        // Inverse property inside Account class
        // which corresponds to other end of this
        // relation
        [InverseProperty("AccountEmails")]
        [ForeignKey("AccountID")]
        public Account Account {get;set;}
    }
    public class Account{
       
        // Inverse property inside AccountEmail class
        // which corresponds to other end of this
        // relation
        [InverseProperty("Account")]
        public ICollection<AccountEmail> AccountEmails {get;set;}
    }
