    public interface ITypeConverter
    {
        string Convert(object propertyValue);
    }
    public interface ITypeConverter<in T> : ITypeConverter
    {
        bool IsValid { get; }
        string Convert(T propertyValue);
    }
    public abstract class TypeConverterBase<T> : ITypeConverter<T>
    {
        public string Convert(object propertyValue)
        {
            //Helper method just to call right overload of generic method.
            return Convert((T) propertyValue);
        }
        public abstract bool IsValid { get; }
        public abstract string Convert(T propertyValue);
    }
    public class UppercaseConverter : TypeConverterBase<string>
    {
        public override bool IsValid { get { return true; } }
        public override string Convert(string propertyValue)
        {
            return propertyValue.ToString().ToUpper();
        }
    }
    private static void Main(string[] args)
    {
        Type type = typeof(UppercaseConverter);
        var converter = (ITypeConverter)Activator.CreateInstance(type);
        var converted = converter.Convert("hello");
        Console.WriteLine(converted);//Prints HELLO
    }
