    public partial class Page2 : System.Windows.Controls.Page
    {
    	public Page2()
    	{
    		InitializeComponent();
    	}
    
        private void PG2_Loaded(object sender, RoutedEventArgs e)
        {
            CreateFrame(this);
        }
        private void CreateFrame(Page page)
        {
            Frame newFrame = new Frame();
            newFrame.Navigate(page);
    
            // The size the page is 525x50
            RenderTargetBitmap renderTargetBitmap =
                new RenderTargetBitmap(525, 50, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(page);
            PngBitmapEncoder pngImage = new PngBitmapEncoder();
    
            pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            using (Stream fileStream = File.Create("c:\\Frame.png"))
            {
                pngImage.Save(fileStream);
    
            }
        }
    }
