    public class MyClass
    {
        public enum Axis { X, Y }
        private Vector2 _vector; //Has to be private
        public Vector2 Vector
        {
            get { return vector; }
            set { vector = value; }
        }
        public float this[Axis axis]
        {
            get { return axis == Axis.X ? vector.x : vector.y; }
            set
            {
                if(axis == Axis.Y)
                {
                    // Special logic here
                    vector.Y = value;
                }
                if(axis == Axis.X)
                {
                    // Special logic here
                    vector.X = value;
                }
            }
        }
    }
