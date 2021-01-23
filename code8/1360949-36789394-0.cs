    [LayoutRenderer("wrap-line")]
    [AmbientProperty("WrapLine")]
    [ThreadAgnostic]
    public sealed class WrapLineRendererWrapper : WrapperLayoutRendererBase
    {
        public WrapLineRendererWrapper ()
        {
            Position = 80;
        }
        [DefaultValue(80)]
        public int Position { get; set; }
        protected override string Transform(string text)
        {
            if(text.Length < Position) return text;
            return text.Insert(Position, Environment.NewLine);
        }
    }
