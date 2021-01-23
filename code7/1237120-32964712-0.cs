    public enum Tilts
    {
        Mm = 0,
        Degree = 1,
        Inch = 2
    }
    public static class TiltsExtensions
    {
        public static string ToSymbol(this Tilts tilts)
        {
            switch (tilts)
            {
                default: return tilts.ToString();
                case Tilts.Degree: return "°";
                // etc;
            }
        }
    }
