    public class ImageGeneratedEventArgs : EventArgs
    {
        public string Path { get; set; }
        public ImageGeneratedEventArgs(string path)
        {
            this.Path = path;
        }
    }
