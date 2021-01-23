    public static void FunctionWithCallBack(string a, string b, Func<string,string,string> callBackFunc)
        {
            string firstArg = a;
            string secondArg = b;
            var result = callBackFunc(firstArg, secondArg);
        }
        public static string CallBackFunctionMethod(string a, string b)
        {
            return a + " " +  b;
        }
    CallBackFunction.FunctionWithCallBack("Aslam", "Shaikh", CallBackFunction.CallBackFunctionMethod);
