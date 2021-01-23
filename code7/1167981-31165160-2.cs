    [AttributeUsage(AttributeTargets.Property)]
    public  class FinalizeRequiredCollectionAttribute : FinalizeValidationAttribute
    {
        protected override bool IsNotNull(object value)
        {
            var enumerable = value as IEnumerable;
            return (enumerable != null && enumerable.GetEnumerator().MoveNext());
        }
    }
