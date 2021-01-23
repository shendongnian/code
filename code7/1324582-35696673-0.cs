    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(EmployeeSharedValidation))]
    public partial class EmployeeShared
    {
      private class EmployeeSharedValidation
      {
         [Required]
         public string Name; 
      }
    }
