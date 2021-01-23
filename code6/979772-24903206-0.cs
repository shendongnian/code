    private void btnLoadImage_Click(object sender, RoutedEventArgs e)
    {
        using (var openImg = new OpenFileDialog())
        {
            ...
            if (openImg.ShowDialog() == DialogResult.Ok)
                LoadImage(openImg.FileName);
        }
    }
    
    private Bitmap _bitmap;
    void LoadImage(string uri)
    {
        // use a BitmapImage for display
        imgDisp.Source = new BitmapImage(new Uri(openImg.FileName));
        
        // use a Bitmap for processing
        _bitmap = new Bitmap(openImg.FileName);
    }
