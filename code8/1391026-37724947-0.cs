    class My : IEquatable<My>
    {
        public bool Equals(My other)
        {
            return new MyIEqualityComparer().Equals(this, other);
        }
    }
