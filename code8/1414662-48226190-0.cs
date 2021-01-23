    class GenericDecorator : DispatchProxy
    {
        public object Wrapped { get; set; }
        public Action<MethodInfo, object[]> Start { get; set; }
        public Action<MethodInfo, object[], object> End { get; set; }
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Start?.Invoke(targetMethod, args);
            object result = targetMethod.Invoke(Wrapped, args);
            End?.Invoke(targetMethod, args, result);
            return result;
        }
    }
