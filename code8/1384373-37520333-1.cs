    var bitmapImage = new BitmapImage(); // An image var
    bitmapImage.BeginInit();
    bitmapImage.UriSource = new Uri("/*image url*/");; // set a value to our var
    bitmapImage.EndInit(); img.Source = bitmapImage;
    if (File.Exists(bitmapImage)){ // checks if the var has an existing image
    //code
    }
