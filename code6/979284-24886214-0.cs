    class MyBase : IEquatable<MyBase>
    {
        public bool Equals(MyBase other)
        {
            return EqualsHelper(other);
        }
        public override bool Equals(object obj)
        {
            return EqualsHelper(obj as MyBase);
        }
        protected bool EqualsHelper(MyBase other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != this.GetType()) return false;
            return EqualsCore(other);
        }
        protected virtual bool EqualsCore(MyBase other)
        {
            return BaseProperty == other.BaseProperty;
        }
        public override int GetHashCode()
        {
            return BaseProperty;
        }
        public int BaseProperty { get; set; }
    }
    class Derived : MyBase, IEquatable<Derived>
    {
        public int DerivedProperty { get; set; }
        public bool Equals(Derived other)
        {
            return EqualsHelper(other);
        }
        protected override bool EqualsCore(MyBase other)
        {
            Derived obj = (Derived)other;
            return base.EqualsCore(obj) &&
                this.DerivedProperty == obj.DerivedProperty;
        }
    }
