    public interface IFluentValidation<T>
    {
         bool IsValid { get; }
         T ObjectToValidate { get; }
    }
    internal class FluentValidation<T>: IFluentValidation<T>
    {
        public bool IsValid { get; }
        public T ObjectToValidate { get; }
        public FluentValidation(bool isValid, T target)
        {
            Debug.Assert(target != null);
            IsValid = isValid;
            ObjectToValidate = target;
        }
    }
