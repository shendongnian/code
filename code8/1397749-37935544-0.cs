    public class Style /*: Component */
    {
        [TypeConverter(typeof(CustomConverter))]
        public CustomBrush Brush { get; set; }
    }
