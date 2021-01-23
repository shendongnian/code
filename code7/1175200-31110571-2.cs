    public class CreateTestDTO : TestDTO
    {
       [Required]
       public DateTime Date { get; set; }
       [Required]
       public int Number { get; set; }
       [Required]
       public int SchoolclassCodeId { get; set; }
       [Required]
       public int SchoolyearId { get; set; }
       [Required]
       public int TestTypeId { get; set; }
   }
    public class EditTestDTO : TestDTO
    {        
       [Required]
       public DateTime Date { get; set; }
       [Required]
       public int Number { get; set; }
       [Required]
       public int SchoolclassCodeId { get; set; }
       [Required]
       public int SchoolyearId { get; set; }
       [Required]
       public int TestTypeId { get; set; }
       [Required]
       public int TestId { get; set; }
