        class BaseClass
        {
            public virtual string prop1 { get; set; }
            public virtual string prop2 { get; set; }
            public virtual string prop3 { get; set; }
            public virtual string prop4 { get; set; }
            public virtual string prop5 { get; set; }
        }
        class C1 : BaseClass
        {
            public override string prop4 { get; set; }
        }
        class C2 : BaseClass
        {
            public override string prop5 { get; set; }
        }
