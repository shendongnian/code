    public class Car
    {
         public int ID { get; set; }
         [Required]
         [CheckSpelling(ErrorMessage = "Check your spelling")]
         public string Make { get; set; }
    }
