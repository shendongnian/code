    public class Value
    {
        private readonly Int32 _value;
        public Value(Int32 value)
        {
            this._value = value;
        }
        public override String ToString()
        {
            return String.Format("Value {0}", this._value);
        }
        public static Value Parse(String str)
        {
            return new Value(Int32.Parse(str));
        }
    }
    public class Converter
    {
        private readonly IDictionary<Type, Func<String, Object>> _parseFunctions;
        public Converter()
        {
            this._parseFunctions = new Dictionary<Type, Func<String, Object>>();
        }
        public T Convert<T>(String str)
        {
            Func<String, Object> parse;
            if (this._parseFunctions.TryGetValue(typeof(T), out parse))
            {
                return (T)parse(str);
            }
            var parseMethodInfo = typeof(T)
                .GetMethod(
                    name: "Parse",
                    bindingAttr: BindingFlags.Static | BindingFlags.Public,
                    binder: null,
                    types: new[] { typeof(String) },
                    modifiers: null);
            if (parseMethodInfo != null)
            {
                var parameters = new [] { Expression.Parameter(typeof(String)) };
                parse = Expression
                    .Lambda<Func<String, Object>>(
                        Expression.Convert(
                            expression: Expression.Call(null, parseMethodInfo, parameters),
                            type: typeof(Object)),
                        parameters: parameters)
                    .Compile();
                this._parseFunctions.Add(typeof(T), parse);
                return (T)parse(str);
            }
            return (T)System.Convert.ChangeType(str, typeof(T));
        }
    }
    public static void Main()
    {
        try
        {
            var converter = new Converter();
            Console.WriteLine(converter.Convert<Int32>("123"));
            Console.WriteLine(converter.Convert<Double>("123.32"));
            Console.WriteLine(converter.Convert<Value>("500"));
            Console.WriteLine(converter.Convert<Value>("600"));
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc);
        }
        Console.WriteLine("Press any key...");
        Console.ReadKey(true);         
    }
