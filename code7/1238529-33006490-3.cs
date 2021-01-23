        public class Point2D<T>
        {
            public readonly T x;
            public readonly T y;
            public Point2D(T x, T y)
            {
                this.x = x;
                this.y = y;
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Point2D<T>) obj);
            }
            protected bool Equals(Point2D<T> other)
            {
                return EqualityComparer<T>.Default.Equals(x, other.x) && EqualityComparer<T>.Default.Equals(y, other.y);
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    return (EqualityComparer<T>.Default.GetHashCode(x)*397) ^ EqualityComparer<T>.Default.GetHashCode(y);
                }
            }
        }
