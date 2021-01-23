    class MyLine
    {
        public MyPoint P1 { get; private set; }
        public MyPoint P2 { get; private set; }
        public MyLine(MyPoint p1, MyPoint p2)
        {
            P1 = p1;
            P2 = p2;
        }
        protected bool Equals(MyLine other)
        {
            return (Equals(P1, other.P1) && Equals(P2, other.P2)) || Equals(P1, other.P2) && Equals(P2, other.P1);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MyLine)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + P1.GetHashCode();
                hash = hash * 23 + P2.GetHashCode();
                return hash;
            }
        }
    }
    class MyPoint
    {
        public string Id { get; private set; }
        public MyPoint(string id)
        {
            Id = id;
        }
        protected bool Equals(MyPoint other)
        {
            return string.Equals(Id, other.Id);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MyPoint)obj);
        }
        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
