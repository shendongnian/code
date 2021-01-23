    [Table("Users")]
    public class User
    {
        [Key]
        [Identity]
        public int Id { get; set; }
    
        public string Login { get; set;}
    
        [Column("FName")]
        public string FirstName { get; set; }
    
        [Column("LName")]
        public string LastName { get; set; }
    
        public string Email { get; set; }
    
        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
