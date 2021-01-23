        class Program
        {
            static double Func(List<Parent> l) { return l[0]._value * 1000 + l[1]._value * l[1]._value; }
            static void Main(string[] args)
            {
                A a = 1.1d;
                B b = 2.2d;
                Console.WriteLine(Func(new List<Parent>() {a,b}));
                Console.WriteLine(Func(new List<Parent>() { a, b })); // compile-time error! yay!
                Console.WriteLine(Func(new List<Parent>() { a, b }) + 123.123d - a * 2); // implicit conversion power
                Console.ReadKey();
            }
        }
        class Parent
        {
            public double _value { get; set; }
        }
        class A : Parent
        {
            public static implicit operator A(double value) { return new A() { _value = value }; }
            public static implicit operator double(A value) { return value._value; }
        }
        class B : Parent
        {
            public static implicit operator B(double value) { return new B() { _value = value }; }
            public static implicit operator double(B value) { return value._value; }
        }
