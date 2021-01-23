    public class ColorPalette
    {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public int a { get; set; }
    }
    
    public class Map
    {
        public int version { get; set; }
        public List<ColorPalette> color_palette { get; set; }
    }
    
    public class RootObject
    {
        public string name { get; set; }
        public string description { get; set; }
        public Map map { get; set; }
    }
