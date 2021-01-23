    public sealed class ViewModelError
    {
        public ViewModelError(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
        public string PropertyName { get; private set; }
        public string ErrorMessage { get; private set; }
    }
