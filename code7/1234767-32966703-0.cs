    [TestMethod]
    public async Task TestMethod2()
    {
        //pixels to test
        byte[] pixels = null;
    
        // Since I create a UI elements, I need to use Dispatcher here.
        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, async () =>
        {
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
    
            // create an instance of RenderTargetBitmap to render a bitmap 
            var rtb = new RenderTargetBitmap();
            await rtb.RenderAsync(element); // exception!
    
            var pixBuffer = await rtb.GetPixelsAsync();
            pixels = pixBuffer.ToArray();
        });
    
        Assert.AreEqual<byte>(255, pixels[0]);
        Assert.AreEqual<byte>(255, pixels[1]);
        Assert.AreEqual<byte>(255, pixels[2]);
        Assert.AreEqual<byte>(255, pixels[3]);
    }
