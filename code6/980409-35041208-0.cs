        [Category("Appearance")]
        public Color PropertyBackColor
        {
            get { return propertyBackColor; }
            set { propertyBackColor = value; }
        }
        Color propertyBackColor = Color.Empty;
        public bool ShouldSerializePropertyBackColor()
        {
            return propertyBackColor != Color.Empty;
        }
        public void ResetPropertyBackColor()
        {
            propertyBackColor = Color.Empty;
        }
