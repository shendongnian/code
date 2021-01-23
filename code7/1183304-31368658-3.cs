    public class OuterClass
    {
        public string StringProperty { get; private set; }
        public  InnerClass CreateInnerClass()
        {
            InnerClass ic = new InnerClass(this);
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
