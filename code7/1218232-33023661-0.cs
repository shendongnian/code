    private class MyBufferedHtmlContent : IHtmlContent
    {
        internal List<IHtmlContent> Entries { get; } = new List<IHtmlContent>();
        public MyBufferedHtmlContent Append(IHtmlContent htmlContent)
        {
            Entries.Add(htmlContent);
            return this;
        }
        public void WriteTo(TextWriter writer, IHtmlEncoder encoder)
        {
            foreach (var entry in Entries)
            {
                entry.WriteTo(writer, encoder);
            }
        }
    }
