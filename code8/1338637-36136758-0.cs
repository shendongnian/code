    class Generic<T>
    {
        public bool Equal(T t1, T t2)
        {
            return t1.Equals(t2);
        }
    }
    class X : IEquatable<X>
    {
        public override bool Equals(object obj)
        {
            Console.WriteLine("object.Equals");
            return true;
        }
        public bool Equals(X other)
        {
            Console.WriteLine("IEquatable.Equals");
            return true;
        }
    }
