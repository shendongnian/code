    public sealed partial class ImageControl : UserControl
    {
        public event EventHandler ImageTapped;
        public void image_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            if (ImageTapped != null)
            {
                ImageTapped(this, EventArgs.Empty);
            }
        }
    }
