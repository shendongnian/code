    public class Car
    {
         public int ID { get; set; }
         [Required]
         [CheckSpelling]
         public string Make { get; set; }
    }
