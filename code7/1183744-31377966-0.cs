    public class Obj:  IEquatable<Obj>
    {
        public List<X> xlist;
        public List<Y> Ylist;
        public bool mybool;
        public bool Equals(Obj other)
        {
            if (other == null) return false;
            if(object.ReferenceEquals(this, other)) return true;
            if (mybool != other.mybool) return false;
            return xlist.SequenceEqual(other.xlist) && Ylist.SequenceEqual(other.Ylist);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = mybool ? 13 : 19;
                foreach (X x in xlist)
                {
                    hash = hash * 31 + x.GetHashCode();
                }
                foreach (Y y in Ylist)
                {
                    hash = hash * 31 + y.GetHashCode();
                }
                return hash;
            }
        }
    }
    public class X: IEquatable<X>
    {
        public int x;
        public float y;
        public bool Equals(X other)
        {
            if (other == null) return false;
            if (object.ReferenceEquals(this, other)) return true;
            return x == other.x && y == other.y;
        }
        public override bool Equals(object obj)
        {
            var other = obj as X;
            if (other == null) return false;
            return this.Equals(other);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                hash = hash * 31 + x;
                hash = hash * 31 + (int)y;
                return hash;
            }
        }
    }
    public class Y : IEquatable<Y>
    {
        public string str;
        public bool y;
        public bool Equals(Y other)
        {
            if (other == null) return false;
            if (object.ReferenceEquals(this, other)) return true;
            return str == other.str && y == other.y;
        }
        public override bool Equals(object obj)
        {
            var other = obj as Y;
            if (other == null) return false;
            return this.Equals(other);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                hash = hash * 31 + (str == null ? 0 : str.GetHashCode());
                hash = hash * 31 + (y ? 1 : 0);
                return hash;
            }
        }
    }
