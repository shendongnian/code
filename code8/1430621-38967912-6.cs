    public class WellSchematic : UserControl
    {
    	public WellSchematic()
    	{
    		InitializeComponent();
            var im1 = CreateImage();
            im1.HorizontalAlignment = HorizontalAlignment.Left;
            im1.VerticalAlignment = VerticalAlignment.Top;
            im1.Margin = new Margin(10,20,0,25);
            im1.Stretch = Stretch.Fill;
            var im2 = CreateImage();
            im2.HorizontalAlignment = HorizontalAlignment.Right;
            im2.VerticalAlignment = VerticalAlignment.Top;
            im2.Margin = new Margin(0,30,20,0);
            var im3 = CreateImage();
            im3.HorizontalAlignment = HorizontalAlignment.Left;
            im3.VerticalAlignment = VerticalAlignment.Bottom;
            im3.Margin = new Margin(40,0,0,10);
            // Add more pictures
        }
        private void CreateImage()
        {
            var image = new Image();
            var bmp = new BitmapImage(new Uri(@"images/casingleg", UriKind.Relative));
            image.Source = bmp;
            image.Width = bmp.Width;
            image.Height = bmp.Height;
            
            schematic.Children.Add(image);
        }
    }
