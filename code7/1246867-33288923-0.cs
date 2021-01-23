    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var container = new Canvas()
        {
            Width = 300,
            Height = 500
        };
        var winImage = new Image()
        {
            Width = 300,
            Height = 500
        };
        container.Children.Add(winImage);
        
        var img = BitmapFactory.New((int)winImage.Width, (int)winImage.Height); 
        winImage.Source = img;
        Content = container;
        var clr = Color.FromArgb(255, 0, 0, 255);
        var random = new Random();
        var sw = new Stopwatch();
        sw.Start();
        
        using (img.GetBitmapContext()) {
            img.Clear(Colors.White);
            for (var x = 0; x < 10; x++) {
              for (var y = 0; y < 10; y++) {
                img.FillRectangle(x * 10, y * 10, x * 10 + 10, y * 10 + 10, clr); 
              }
            }
        }
        
        sw.Stop();
        
        Debug.WriteLine(sw.ElapsedMilliseconds + "ms drawing");
    }
