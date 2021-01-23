    public sealed class MyKey : IEquatable<MyKey>, IComparable<MyKey> {
        public readonly short X;
        public readonly short Y;
        public readonly DateTime Date;
        public MyKey(short x, short y, DateTime date) {
            this.X = x;
            this.Y = y;
            this.Date = date;
        }
        public override bool Equals(object that) {
            return this.Equals(that as MyKey);
        }
        public bool Equals(MyKey that) {
            if(that == null) {
                return false;
            }
            return this.Date == that.Date
                && this.X == that.X
                && this.Y == that.Y;
        }
        public static bool operator ==(MyKey lhs, MyKey rhs) {
            return lhs != null ? lhs.Equals(rhs) : rhs == null;
        }
        public static bool operator !=(MyKey lhs, MyKey rhs) {
            return lhs != null ? !lhs.Equals(rhs) : rhs != null;
        }
        public override int GetHashCode() {
            int result;
            unchecked {
                result = (int)X;
                result = 31 * result + (int)Y;
                result = 31 * result + Date.GetHashCode();
            }
            return result;
        }
        public int CompareTo(MyKey that) {
            int result = this.X.CompareTo(that.X);
            if(result != 0) {
                return result;
            }
            result = this.Y.CompareTo(that.Y);
            if(result != 0) {
                return result;
            }
            result = this.Date.CompareTo(that.Date);
            return result;
        }
    }
