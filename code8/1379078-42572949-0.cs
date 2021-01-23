    [Table("Users")]
    public class User
    {
       [Key]
       public int UserId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public int Age { get; set; }
      //Additional properties not in database
      [Editable(false)]
      public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
       public List<User> Friends { get; set; }
       [ReadOnly(true)]
       public DateTime CreatedDate { get; set; }
    }
    var newId = connection.Insert(new User { FirstName = "User", LastName = "Person",  Age = 10 });  
