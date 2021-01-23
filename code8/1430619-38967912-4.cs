    public class WellSchematic : UserControl
    {
    	public WellSchematic()
    	{
    		InitializeComponent();
    	    AddImage();
            AddImage();
        }
        private void AddImage()
        {
            var image = new Image();
            var bmp = new BitmapImage(new Uri(@"images/casingleg", UriKind.Relative));
            image.Source = bmp;
            image.Width = bmp.Width;
            image.Height = bmp.Height;
            schematic.Children.Add(image);
        }
    }
