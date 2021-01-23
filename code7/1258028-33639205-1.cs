    [DebuggerDisplay("{ToString()}")]
    public struct MyDateTimeWrapperStruct
    {
        private readonly DateTime _value;
        public MyDateTimeWrapperStruct(DateTime value)
        {
            _value = value;
        }
        public override string ToString() => _value.ToString("MM/dd/yyyy");
    }
