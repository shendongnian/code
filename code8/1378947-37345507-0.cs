    class A : IEquatable<A>
    {
        public A(string Test) { this.Test = Test; }
        public string Test;
        public bool Equals(A other)
        {
            return Equals(Test, other.Test);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((A)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                unchecked
                {
                    return Test.GetHashCode();
                }
            }
        }
        public string ToString() { return Test; }
    }
