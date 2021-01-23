    [DefaultEvent("LoadPicture")]
    public partial class cntrlImageLoader : UserControl
    {
        public delegate void LoadPictureEventHandler(object sender, LoadPictureEventArgs e);
        public event LoadPictureEventHandler LoadPicture;
    
        private void pbImage_DoubleClick(object sender, EventArgs e)
        {
            if (LoadPicture != null)
            {
                LoadPictureEventArgs ev = new LoadPictureEventArgs();
                LoadPicture(this, ev);
                if (ev.Picture != null)
                {
                    pbImage.Image = ev.Picture;
                }
            }
        }
    
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
    }
