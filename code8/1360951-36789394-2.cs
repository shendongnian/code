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
            return string.Join(Environment.NewLine, MakeChunks(text, Position));
        }
        private static IEnumerable<string> MakeChunks(string str, int chunkLength)
        {
            if (String.IsNullOrEmpty(str)) throw new ArgumentException();
            if (chunkLength < 1) throw new ArgumentException();
            for (int i = 0; i < str.Length; i += chunkLength)
            {
                if (chunkLength + i > str.Length)
                    chunkLength = str.Length - i;
                yield return str.Substring(i, chunkLength);
            }
        }
    }
