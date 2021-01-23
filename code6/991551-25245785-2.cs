    static class SimpleShapeFactory
    {
        #region Private Members
        public static readonly Type[] _shapes = new Type[]
        {
            typeof(Shape),
            typeof(Circle),
            typeof(Triangle)
        };
        #endregion // Private Members
        #region Methods
        /// <summary>
        /// Creates shape by it's name
        /// </summary>
        /// <param xmlName="name">Name of the shape</param>
        /// <returns>Created shape</returns>
        public static Shape Create(string name)
        {
            foreach(var shape in _shapes)
            {
                var attribute = (ShapeNameAttribute)shape.GetCustomAttributes(typeof(ShapeNameAttribute), true)[0];
                if(attribute.Name == name)
                {
                    return (Shape)Activator.CreateInstance(shape);
                }
            }
            throw new ArgumentException("Invalid name");
        }
        #endregion // Methods
    }
