    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class RequiredCollectionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ErrorMessage = "You must provide at least one.";
            var collection = value as ICollection;
            return collection != null || collection.Count > 0;
        }
    }
