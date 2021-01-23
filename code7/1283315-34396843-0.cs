        public class A
        {
            private static int _idA;
            public virtual int Id
            {
                get { return _idA; }
                set { _idA = value; }
            }
        }
        public class B : A
        {
            private static int _idB;
            public override int Id
            {
                get { return _idB; }
                set { _idB = value; }
            }
        }
