    public class LoadPictureEventArgs : EventArgs
    {
        public Image Picture {get; set;}
        public LoadPictureEventArgs(Image _picture)
        {
            Picture = _picture
        }
        public LoadPictureEventArgs()
                        : base()
        {
        }
    }
