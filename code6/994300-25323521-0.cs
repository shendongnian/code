    public class Function 
    {
        private static readonly IDictionary<FunctionType, Func<int, int, string>> functionMappings = 
            new Dictionary<FunctionType, Func<int, int, string>>
        {
            { FunctionType.PLUS, ExecuteFunction.DOPLUS },
            { FunctionType.MINUS, ExecuteFunction.DOMINUS },
            { FunctionType.MULTIPLY, ExecuteFunction.DOMULTIPLY },
            { FunctionType.DIVIDE, ExecuteFunction.DODIVIDE },
        };
        public string Execute()
        {
            return functionMappings[_functionType]((int)Params[0], (int)Params[1]);
        }
    }
