    public class OuterClass
    {
        public string StringProperty { get; private set; }
        public static  InnerClass CreateInnerClass( OuterClass oc)
        {
            InnerClass ic = new InnerClass(oc);
            return ic;
        }
        private class InnerClass
        {
            private OuterClass _outer;
            public InnerClass(OuterClass oc)
            {
                _outer = oc;
            }
            public string StringProperty
            {
                get
                {
                    return _outer.StringProperty;
                }
                set
                {
                    _outer.StringProperty = value;
                }
            }
        }
    }
