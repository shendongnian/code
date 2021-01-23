    public class MyClass
    {
        private Vector2 _vector; //Has to be private
        public Vector2 Vector
        {
            get { return vector; }
            set { vector = value; }
        }
    
        public float VectorX
        {
            get { return _vector.X; }
            set { _vector.X = value; }
        }
    
        public float VectorY
        {
            get { return _vector.Y; }
            set { _vector.Y = value; }
        }
    }
