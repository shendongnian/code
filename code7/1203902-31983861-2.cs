    public class Allocation
    {
         [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public int id { get; set; }
         [Required]
         public string one { get; set; }
         [Required]
         public string two { get; set; }
         [Required]
         public string three { get; set; }
    }
