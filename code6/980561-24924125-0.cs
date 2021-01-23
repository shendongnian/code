        public class Message
        {
            protected bool Equals(Message other)
            {
                return string.Equals(x, other.x) && string.Equals(y, other.y) && string.Equals(z, other.z) && string.Equals(w, other.w);
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Message) obj);
            }
            public override int GetHashCode()
            {
                unchecked //Ignores overflows that can (should) occur
                {
                    var hashCode = x;
                    hashCode = (hashCode*397) ^ (y != null ? y.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (z != null ? z.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (w != null ? w.GetHashCode() : 0);
                    return hashCode;
                }
            }
            public int x { get; set; }
            public string y { get; set; }
            public string z { get; set; }
            public string w { get; set; }
        }
