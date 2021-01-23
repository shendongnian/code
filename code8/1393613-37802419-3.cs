    public class Car
    {
         public int ID { get; set; }
         [Required]
         [Spelling(ErrorMessage ="Invalid Spelling")
         public string Make { get; set; }
    }
