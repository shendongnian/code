    public static class Arguments
    {
        // This convenience method enables type-inference, so the generic types
        // don't need to be supplied (which is necessary when calling the
        // Arguments<T1, T2, T3> constructor):
        public static Arguments<T1, T2, T3> Create<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3)
        {
            return new Arguments<T1, T2, T3>(arg1, arg2, arg3);
        }
    }
    public class Arguments<T1, T2, T3>
    {
        public T1 Argument1 { get; set; }
        public T2 Argument2 { get; set; }
        public T3 Argument3 { get; set; }
        public Arguments(T1 arg1, T2 arg2, T3 arg3)
        {
            Argument1 = arg1;
            Argument2 = arg2;
            Argument3 = arg3;
        }
    }
