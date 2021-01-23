    public class MyValidationAttribute : ValidationAttribute, IClientValidatable {
    public IEnumerable<ModelClientValidationRule> GetClientValidationRules( ModelMetadata metadata,
         ControllerContext context )
      {
         yield return new ModelClientValidationRule {ValidationType = "[javascript function name for client validation]"};
      }
    public override bool IsValid( object value )
      {
         // logic here
      }
}
