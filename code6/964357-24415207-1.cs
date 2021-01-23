        public static object CallFunction(object item) { return item; }
        public static object AnotherFunctionCall(object item) { return item; }
        public static object ThirdFunctionCall(object item) { return item; }
        public static MethodInfo CallFunctionMethodInfo = typeof(BuildFunction).GetMethod("CallFunction");
        public static MethodInfo AnotherFunctionCallMethodInfo = typeof(BuildFunction).GetMethod("AnotherFunctionCall");
        public static MethodInfo ThirdFunctionCallMethodInfo = typeof(BuildFunction).GetMethod("ThirdFunctionCall");
        public static Func<object, object> CreateFunc(bool boolA, bool boolB)
        {
            var objectParameter = Expression.Parameter(typeof(object));
            var returnVar = Expression.Variable(typeof(object), "returnVar");
            var commands = new List<Expression>();
            commands.Add(
                Expression.Assign(
                returnVar,
                Expression.Call(CallFunctionMethodInfo, objectParameter)));
            
            if (boolA)
            {
                commands.Add(
                    Expression.Assign(
                    returnVar,
                    Expression.Call(AnotherFunctionCallMethodInfo, returnVar)));
            }
            if (boolB)
            {
                commands.Add(
                    Expression.Assign(
                    returnVar,
                    Expression.Call(ThirdFunctionCallMethodInfo, returnVar)));
            }
            commands.Add(returnVar);
            var body = Expression.Block(new[] { returnVar }, commands);
            return Expression.Lambda<Func<object, object>>(body, objectParameter).Compile();
        }
