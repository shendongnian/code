    public class EditTestDTO : IValidatableObject
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
       
       public int? TestId { get; set; }
       public bool IsEdit {get;set;}
       public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
       {
          if(IsEdit) 
          {
              if(!TestId.HasValue)
              {
                  yield return new ValidationResult();
              }
          }
       }
    }
