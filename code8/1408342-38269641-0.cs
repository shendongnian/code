     interface IInterface
     {
         int Transform(int a, int b);
     }
     class A : IInterface
     {
        public virtual int Transform(int a, int b)
        {
            return a + b;
        }
     }
     class B : A
     {
        public override int Transform(int a, int b)
        {
            return a - b;
        }
     }
