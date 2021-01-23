    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CallMethodAttribute : Attribute
    {
        private readonly FunctionType mFunctionType;
        public CallMethodAttribute(FunctionType functionType)
        {
            mFunctionType = functionType;
        }
        public FunctionType FunctionType
        {
            get { return mFunctionType; }
        }
    }
