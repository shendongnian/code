    public class Geometry
    {
        // I don't know what is the implementation of bounds, so 
        // I'm just assuming that is something comparable here.
        public Rectangle Bounds { get; set; }
        // Here's your definition of Geometry.Empty, from what I understood.
        public static Geometry Empty
        {
            get
            {
                return new Geometry { Bounds = new Rectangle(0, 0, 0, 0) };
            }
        }
        // Here is the key: you must override the default operators of equality
        // and difference to make comparations to work, because internally it will
        // use them.
        public static bool operator ==(Geometry left, Geometry right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            if (left != null && right != null)
            {
                return left.Bounds == right.Bounds;
            }
            return false;
        }
        public static bool operator !=(Geometry left, Geometry right)
        {
            if (left == null && right == null)
            {
                return false;
            }
            if (left != null && right != null)
            {
                return left.Bounds != right.Bounds;
            }
            return true;
        }
        // I recommend you to override Equals method of
        // System.Object too. For Assert.AreEqual to work,
        // actually this method will be used.
        public override bool Equals(object obj)
        {
            var objAsGeometry = obj as Geometry;
            if (obj == null)
            {
                return false;
            }
            return objAsGeometry.Bounds == this.Bounds;
        }
        // GetHashCode is used in some types of comparations too,
        // altough not in your case with Assert.AreEqual.
        // If you want to make a fully comparable object, 
        // be sure to override it too, with all conditions used
        // to compare one Geometry object with other.
        public override int GetHashCode()
        {
            return Bounds.GetHashCode();
        }
    }
