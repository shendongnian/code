        public class AdapterA : IAdapter
        {
            public ObjectTypeA Obj { get; set; }
            public AdapterA()
            {
                Obj = new ObjectTypeA();
            }
            public void DoSomething()
            {
                Obj.Prop1 = true;
            }
        }
        public class AdapterB : IAdapter
        {
            public ObjectTypeB Obj { get; set; }
            public AdapterB()
            {
                Obj = new ObjectTypeB();
            }
            public void DoSomething()
            {
                Obj.Prop1 = true;
            }
        }
