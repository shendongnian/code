    using System.Drawing;
    using Microsoft.Interop.Word;
    static class ColorExtensions
    {
        public static WdColor ToWdColor(this Color color)
        {
            return (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);
        }
    }
