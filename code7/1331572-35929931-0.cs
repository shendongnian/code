    public class PrimaryPalette : MarkupExtension
    {
        public static Dictionary<PrimaryPaletteColours, Color> Palette => 
            new Dictionary<PrimaryPaletteColours, Color>
            {
                { PrimaryPaletteColours.CustomMagenta,    Color.FromArgb(0xFF, 0xDA, 0x42, 0xAA) },
                { PrimaryPaletteColours.CustomBlue,       Color.FromArgb(0xFF, 0x11, 0x42, 0xFF) },
                { PrimaryPaletteColours.CustomGreen,      Color.FromArgb(0xFF, 0x33, 0xDE, 0x60) },
                { PrimaryPaletteColours.CustomOrange,     Color.FromArgb(0xFF, 0xDA, 0x80, 0x22) },
                { PrimaryPaletteColours.CustomPurple,     Color.FromArgb(0xFF, 0xCC, 0x00, 0xFF) },
                { PrimaryPaletteColours.CustomRed,        Color.FromArgb(0xFF, 0xEE, 0x42, 0x00) },
                { PrimaryPaletteColours.CustomTurqoise,   Color.FromArgb(0xFF, 0x10, 0xAB, 0xBC) },
                { PrimaryPaletteColours.CustomGold,       Color.FromArgb(0xFF, 0xDA, 0xA0, 0x22) }
            };
        public PrimaryPalette() { }
        public PrimaryPalette(PrimaryPaletteColours key) { Key = key; }
        [ConstructorArgument("Key")]
        public PrimaryPaletteColours Key { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            try
            {
                return new SolidColorBrush(Palette[Key]);
            }
            catch
            {
                return new SolidColorBrush(Colors.Transparent);
            }
        }
    }
    public enum PrimaryPaletteColours
    {
        CustomMagenta,
        CustomBlue,
        CustomGreen,
        CustomOrange,
        CustomPurple,
        CustomRed,
        CustomTurqoise,
        CustomGold
    }
