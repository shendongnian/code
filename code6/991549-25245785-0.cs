    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    sealed class ShapeNameAttribute : Attribute
    {
        #region Constructors
        public ShapeNameAttribute(string name)
        {
            Name = name;
        }
        #endregion // Constructors
        
        #region Properties
        public string Name
        {
            get;
            set;
        }
        #endregion // Properties
    }
