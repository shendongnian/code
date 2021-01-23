    [Table("tbl_useraccount")]
    public class AccountModel
    {
       [Key]
       public string AccountId { get; set; }
       public string Email { get; set; }
       public string HashPassword { get; set; }
    }
    [Table("tbl_userprofile")]
    public class UserProfileModels
    {
       [Key]
       public int Id { get; set; }
       public string AccountId { get; set; }
       public string Address { get; set; }
       [ForeignKey("AccountModel")]
       public int PhoneNumber { get; set; }
       
       public virtual AccountModel AccountModel { get; set;}
    }
