    public class MyClass
    {
            private void MyClass() { } //just to satisfy the XML serializer
            public void MyClass(int a, int b)
            {
                A = a;
                B = b;
            }
            public int A { get; set; }
            public int B { get; set; }
            public int C
            {
                get
                {
                    return A + B;
                }
                set { }
            }
            public void DoSomeMath()
            {
                Console.WriteLine("{0} + {1} = {2}\n", A, B, C)
            }
        }
