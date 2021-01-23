    namespace WebPortalMVC.Models
    {
    [Table("UsersAndRoles")]
    public class RegisterModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
        public int CustomerId { get; set; }
          
        [Display(Name = "Customer ID")]
        public int SelectedCustomerId { get; set; }
        public IEnumerable<SelectListItem> CustomerID { get; set; }
    }
    
    public class DbCustomerId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
        
    public class UsersAndRolesDBContext : DbContext
    {
        public UsersAndRolesDBContext() : base("MySqlConnection")
        {
      
        }
        public DbSet<RegisterModel> UsersAndRoles { get; set; }
        }
    }
