        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // writes "Image1" or "Image2", depending on clicked image
            Debug.WriteLine(((Image)e.OriginalSource).Name);
        }
