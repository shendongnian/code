    public abstract class ProductAttribute { }
    public sealed class Color : ProductAttribute {
        private Color(string value) { Value = value; }
        public Value { get; }
        public static readonly Blue = new Color("blue");
        public static readonly Green = new Color("green");
        private static readonly IReadOnlyDictionary<string, Color> _colorDict = 
           new ReadOnlyDictionary<string, Color>(
              new List<Color> {
                 Blue, Green
              }.ToDictionary(color => color.Value, color => color)
           );
        public static Color GetColor(string value) {
           Color color;
           _colorDict.TryGetValue(value, out color);
           return color;
        }
    }
