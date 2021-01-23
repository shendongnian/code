    public class ClassNameRequiredAttribute : RequiredAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            MyAssetClass myAssetClass = (MyAssetClass)type.GetProperty("MyAssetClass").GetValue(instance, null);
            if (!string.IsNullOrEmpty(myAssetClass.assetClassName))
            {
                if (myAssetClass.allowedClassNames.Contains(myAssetClass.assetClassName))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage);
        }
    }
