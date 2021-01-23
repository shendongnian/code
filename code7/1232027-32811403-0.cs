    class ImmutableClass
    {
        private readonly int _field1;
        private readonly int _field2;
        public ImmutableClass(int field1, int field2)
        {
            _field1 = field1;
            _field2 = field2;
        }
        private ImmutableClass(ImmutableClass src, int? field1 = null, int? field2 = null)
        {
            _field1 = field1 ?? src._field1;
            _field2 = field2 ?? src._field2;
        }
        //choose a more domain-related name
        public ImmutableClass ModifyField1(int value)
        {
            return new ImmutableClass(this, field1: value);
        }
        //choose a more domain-related name
        public ImmutableClass ModifyField2(int value)
        {
            return new ImmutableClass(this, field2: value);
        }
        //just an example - I wouldn't do it in my code
        public ImmutableClass ModifyFields(int? field1 = null, int? field2 = null)
        {
            return new ImmutableClass(this, field1, field2);
        }
    }
