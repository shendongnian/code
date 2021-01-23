        public class BOX
        {
            double height, length, breadth;
            public static bool operator == (BOX b1, BOX b2)
            {
                if (null == b1)
                    return (null == b2);
                return b1.Equals(b2);
            }
            public static bool operator != (BOX b1, BOX b2)
            {
                return !(b1 == b2);
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;
                var b2 = (BOX)obj;
                return (length == b2.length && breadth == b2.breadth && height == b2.height);
            }
            public override int GetHashCode()
            {
                return height.GetHashCode() ^ length.GetHashCode() ^ breadth.GetHashCode();
            }
        }
