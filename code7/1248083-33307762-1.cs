        private void LoadImage()
        {
            var image = Services.GetImage(_employeeID);
            if (image.Image != null)
            {
                MemoryStream strmImg = new MemoryStream(image.Image);
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.StreamSource = strmImg;
                myBitmapImage.DecodePixelWidth = 200;
                myBitmapImage.DecodePixelWidth = 250;
                myBitmapImage.EndInit();
                this.DemographicInformation.Image = myBitmapImage;
            }
        }
