    public class ResponseFileInfo
    {
        public string Name { get; private set; }
        public Stream Content { get; private set; }
        public ResponseFileInfo(string name, Stream content)
        {
            Name = name;
            Content = content;
        }
    }
