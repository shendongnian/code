    public class Style /*: Component */
    {
        [TypeConverter(typeof(CustomBrushConverter))]
        public CustomBrush Brush { get; set; }
    }
