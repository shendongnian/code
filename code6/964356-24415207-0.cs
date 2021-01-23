        public static object CallFunction(object item) { return item; }
        public static object AnotherFunctionCall(object item) { return item; }
        public static object ThirdFunctionCall(object item) { return item; }
        public static MethodInfo CallFunctionMethodInfo = typeof(BuildFunction).GetMethod("CallFunction");
        public static MethodInfo AnotherFunctionCallMethodInfo = typeof(BuildFunction).GetMethod("AnotherFunctionCall");
        public static MethodInfo ThirdFunctionCallMethodInfo = typeof(BuildFunction).GetMethod("ThirdFunctionCall");
        public static Func<object, object> CreateFunc(bool boolA, bool boolB)
        {
            var objectParameter = Expression.Parameter(typeof(object));
            var commands = new List<Expression>();
            commands.Add(Expression.Call(CallFunctionMethodInfo, objectParameter));
            if (boolA)
            {
                commands.Add(Expression.Call(AnotherFunctionCallMethodInfo, objectParameter));
            }
            if (boolB)
            {
                commands.Add(Expression.Call(ThirdFunctionCallMethodInfo, objectParameter));
            }
            var body = Expression.Block(commands);
            return Expression.Lambda<Func<object, object>>(body, objectParameter).Compile();
        }
