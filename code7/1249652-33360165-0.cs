    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
      MemoryStream memoStream = new MemoryStream();
      using (FileStream fs = File.OpenRead("TestImage.bmp"))
      {
        fs.CopyTo(memoStream);
        BitmapImage bmi = new BitmapImage();
        bmi.BeginInit();
        bmi.StreamSource = memoStream;
        bmi.EndInit();
        ImageBrush brush = new ImageBrush(bmi);
        myCanvas.Background = brush;
        fs.Close();
      }
    }
