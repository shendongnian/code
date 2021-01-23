    public class Parent : Form
    {
         var popup = new Popup();
         popup.BackgroundImageChanged += (sender, args) => this.BackgroundImage = args.Image;
         //...
    }
    public class Popup : Form
    {
        public event EventHandler<ImageChangedEventArgs> BackgroundImageChanged;
        private void SelectImage()
        {
            // ...
            OnBackgroundImageChanged(pictureBoxBackground.Image);
        }
        private void OnBackgroundImageChanged(string image)
        {
            if(BackgroundImageChanged != null)
            {
                var e = new ImageChangedEventArgs(image);
                BackgroundImageChanged(this, e);
            }
        }
    }
    public class ImageChangedEventArgs : EventArgs
    {
        public ImageChangedEventArgs(string image)   
        {
            Image = image;
        }
        public string Image { get; private set; }
    }
