    public static class ExecuteFunction
    {
        [CallMethod(FunctionType.PLUS)]
        public static string DOPLUS(int a, int b)
        {
            return (a + b).ToString();
        }
        [CallMethod(FunctionType.MINUS)]
        public static string DOMINUS(int a, int b)
        {
            return (a - b).ToString();
        }
        [CallMethod(FunctionType.MULTIPLY)]
        public static string DOMULTIPLY(int a, int b)
        {
            return (a * b).ToString();
        }
        [CallMethod(FunctionType.DIVIDE)]
        public static string DODIVIDE(int a, int b)
        {
            return (a / b).ToString();
        }
    }
