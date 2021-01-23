            interface I1 { }
            class AClass : I1 { }
            class Base { }
            static void Main(string[] args)
            {
                I1 myAClass = new AClass();
                Base x = myAClass as Base;
            }
