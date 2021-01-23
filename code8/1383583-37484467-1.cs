    // Holds the common properties for future processing.
    public partial class Product : IDefinedColor
    {
        public string Color
        {
            get { return ProductColor; }
            set { ProductColor = value; }
        }
    }
