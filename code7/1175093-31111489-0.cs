    private interface ICustomConverter
    {
        Type SourceType { get; }
        object CallConvert(string input);
    }
    public abstract class CustomConverter<T> : ICustomConverter
    {
        public abstract T Convert(string input);
        public Type SourceType
        {
            get { return typeof (T); }
        }
        object ICustomConverter.CallConvert(string input)
        {
            return Convert(input);
        }
    }
