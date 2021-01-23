    public class Arguments
    {
        public static Arguments<T1, T2, T3> Create<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            return new Arguments<T1, T2, T3>(action, arg1, arg2, arg3);
        }
    }
    public class Arguments<T1, T2, T3>
    {
        public Argument<T1> Argument1 { get; set; }
        public Argument<T2> Argument2 { get; set; }
        public Argument<T3> Argument3 { get; set; }
        
        
        public Arguments(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            var methodInfo = action.GetMethodInfo();
            var parameters = methodInfo.GetParameters();
            
            Argument1 = new Argument<T1>(parameters[0].Name, arg1);
            Argument2 = new Argument<T2>(parameters[1].Name, arg2);
            Argument3 = new Argument<T3>(parameters[2].Name, arg3);
        }
    }
    // A wrapper class to hold both the name and value of a parameter/argument:
    public class Argument<T>
    {
        public string Name { get; private set; }
        public T Value { get; set; }
        
        
        public Argument(string name, T value)
        {
            Name = name;
            Value = value;
        }
    }
