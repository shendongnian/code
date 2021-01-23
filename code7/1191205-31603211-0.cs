        private void Open_Click(object sender, RoutedEventArgs e)
        {
            PatternWindow.IsOpen = true;
    
            Microsoft.Win32.OpenFileDialog openFileDialong1 = new Microsoft.Win32.OpenFileDialog();
            openFileDialong1.Filter = "Image files (.jpg)|*.jpg";
            openFileDialong1.Title = "Open an Image File";
            openFileDialong1.ShowDialog();
            string fileName = openFileDialong1.FileName;
            try
            {
                //here you create a bitmap image from filename
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bi.UriSource = new Uri(fileName);
                bi.EndInit();
                patternImage.Source = bi;
            }
            catch (Exception ex)
            {
               //throw exception
            }
        }
