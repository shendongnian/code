    public class MyClass
    {
        private void MyClass() // NOT just to satisfy the XML serializer
        {
            GetStuffReady();
        }
    
        public void MyClass(int a, int b)
        {
            A = a;
            B = b;
            GetStuffReady();
        }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; private set; }
    
        public void GetStuffReady()
        {
            C = A + B;
        }
    
        public void DoSomeMath()
        {
            Console.WriteLine("{0} + {1} = {2}\n", A, B, C)
        }
    }
