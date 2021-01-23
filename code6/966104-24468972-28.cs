    public static class LogicalFlow
    {
        private static readonly string _name = typeof (LogicalFlow).Name;
        private static ImmutableStack<Guid> LogicalStack
        {
            get
            {
                return CallContext.LogicalGetData(_name) as ImmutableStack<Guid> ?? ImmutableStack.Create<Guid>();
            }
            set
            {
                CallContext.LogicalSetData(_name, value);
            }
        }
        public static Guid CurrentId
        {
            get
            {
                var logicalStack = LogicalStack;
                return logicalStack.IsEmpty ? Guid.Empty : logicalStack.Peek();
            }
        }
    }
