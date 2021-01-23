    public class Contact
    {
       public int Id { get; set; }
       public string CustomerId { get; set; }
       public string LastName { get; set; }
       public string FirstName { get; set; }
       public string OfficeLocation { get; set; }
       
       //Navigation properties
       [ForeignKey("CustomerId")]
       [Required]
       public Customer Customer { get; set; }
    }
