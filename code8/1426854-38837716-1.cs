       public class Person
       {
           [Required]
           [StringLength(50)]
           string FirstName { get; set; }
    
           [Required]
           [StringLength(50)]
           string LastName { get; set; }
       }
