    public interface IValidator
    {
        bool Validate(object value);
        string ErrorMessage { get; set; }
    }
