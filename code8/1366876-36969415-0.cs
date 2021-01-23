    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int GenderID { get; set; }
        [NotMapped]
        public virtual UserGender Gender 
        {
            get
            {
                 return (UserGender)GenderID;
            }
            set
            {
                 GenderID = Convert.ToInt32(value);
            }
        }
        public string Address { get; set; }
    }
