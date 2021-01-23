        public class AdapterA : ObjectTypeA, IAdapter
        {
            public void SetProp1ToTrue()
            {
                this.Prop1 = true;
            }
        }
        public class AdapterB : ObjectTypeB, IAdapter
        {
            public void SetProp1ToTrue()
            {
                this.Prop1 = true;
            }
        }
