    public partial class PropertiesClass
    {
        public string colorNow { get; set; } = ColorTranslator.ToHtml(Color.FromArgb(Color.Black.ToArgb()));
        public string backgroundColor { get; set; } = ColorTranslator.ToHtml(Color.FromArgb(Color.Black.ToArgb()));
        public string externalLineColor { get; set; } = ColorTranslator.ToHtml(Color.FromArgb(Color.DarkBlue.ToArgb()));
        public string firstColor { get; set; } = ColorTranslator.ToHtml(Color.FromArgb(Color.Goldenrod.ToArgb()));
        public string secondColor { get; set; } = ColorTranslator.ToHtml(Color.FromArgb(Color.DarkGoldenrod.ToArgb()));
        public string mouseEnterColor { get; set; } = ColorTranslator.ToHtml(Color.FromArgb(Color.PaleGoldenrod.ToArgb()));
        public string doubleClickColor { get; set; } = ColorTranslator.ToHtml(Color.FromArgb(Color.Gold.ToArgb()));
        public bool shouldIChangeTheColor { get; set; } = true;
        public bool selectedToMove { get; set; } = true;
        public bool selectedToLink { get; set; } = true;
    }
