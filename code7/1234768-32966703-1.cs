    [TestMethod]
    public async Task TestMethod4()
    {
        //pixels to test
        byte[] pixels = null;
    
        // Since I create a UI elements, I need to use Dispatcher here.
        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, async () =>
        {
            var grid = Window.Current.Content as Grid;
                    
            // Here I create a visual element that I want to test
            var brush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            var element = new Border()
            {
                MinWidth = 20,
                MinHeight = 20,
                Background = brush,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                BorderThickness = new Thickness(0)
            };
    
            grid.Children.Add(element);
    
            try
            {
    
                // create an instance of RenderTargetBitmap to render a bitmap 
                var rtb = new RenderTargetBitmap();
                await rtb.RenderAsync(element);
    
                var pixBuffer = await rtb.GetPixelsAsync();
                pixels = pixBuffer.ToArray();
            }
            finally
            {
                grid.Children.Remove(element);
            }
        });
    
        Assert.AreEqual<byte>(255, pixels[0]);
        Assert.AreEqual<byte>(255, pixels[1]);
        Assert.AreEqual<byte>(255, pixels[2]);
        Assert.AreEqual<byte>(255, pixels[3]);
    }
