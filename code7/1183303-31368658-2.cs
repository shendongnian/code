    public class OuterClass
    {
        public string StringProperty { get; private set; }
        public  InnerClass CreateInnerClass(OuterClass oc)
        {
            InnerClass ic = new InnerClass(oc);
            return ic;
        }
        public class InnerClass
        {
            private OuterClass _outer;
            public InnerClass(OuterClass oc)
            {
                _outer = oc;
            }
            public string Prop
            {
                get
                {
                    return _outer.StringProperty ;
                }
                set
                {
                    _outer.StringProperty = value;
                }
            }
        }
    }
