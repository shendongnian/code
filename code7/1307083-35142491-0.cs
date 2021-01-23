    [MetadataType(typeof(ICustomerValidation1))]
    public class CustomerValidation1 : CustomerBase { }
    public class CustomerBase
    {
      public string Title { get; set; }
    }
    public interface ICustomerValidation1
    {
      // Apply RequiredAttribute
      [Required(ErrorMessage = "Title is required.")]
      string Title { get; }
    }
