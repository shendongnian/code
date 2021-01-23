    public class MethodArguments
    {
        public Argument[] Arguments { get; private set; }
        
        
        public MethodArguments(params object[] arguments)
        {
            // Skip 2 frames: GetCallerParameter and this constructor, so we get the parameters
            // of the method that called this constructor. One caveat is that
            // a MethodArguments object must be created directly by a method
            // that uses it, you can't have a helper method in-between.
            var parameters = GetCallerParameters(2);
            if (parameters.Length != arguments.Length)
                throw new InvalidOperationException("The number of arguments must match the number of parameters.");
            
            Arguments = parameters
                .Select((parameter, index) => new Argument(parameter.Name, parameter.ParameterType, arguments[index]))
                .ToArray();
        }
        
        
        private static ParameterInfo[] GetCallerParameters(int skipFrames = 1)
        {
            var methodBase = new StackFrame(skipFrames).GetMethod();
            var methodBody = methodBase.GetMethodBody();
            return methodBase.GetParameters();
        }
    }
    
    public class Argument
    {
        public string Name { get; private set; }
        public Type Type { get; private set; }
        public object Value { get; private set; }
        
        
        public Argument(string name, Type type, object value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
