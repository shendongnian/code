    private void DisplayAllImages()
        {
            
            byte[] image1 = new byte[4096];
            byte[] image2 = new byte[4096];
            byte[] image3 = new byte[4096];
            byte[] image4 = new byte[4096];
    
            byte[] imageSize = File.ReadAllBytes(ImagePath);
    
            for (int i = 0; i < 4096; i++)
            {
                uint temp = BitConverter.ToUInt32(imageSize, i * 4);
                uint t = temp;
                image1[i] = (byte)(t >> 20);
                t = temp << 10;
                image2[i] = (byte)(t >> 20);
                t = temp << 20;
                image3[i] = (byte)(t >> 21);
                t = temp << 31;
                image4[i] = (byte)t;
            }
    
            DifferenceImage.Source = DisplayAllImages(image1, 64, 64);
            ReferenceImage.Source = DisplayAllImages(image2, 64, 64);
            ScanImage.Source = DisplayAllImages(image3, 64, 64);
            BinImage.Source = DisplayAllImages(image4, 64, 64);
        }
    
        private WriteableBitmap DisplayAllImages(byte[] imageData,int height,int width)
        {
            if (imageData != null)
            {
    
                PixelFormat format = PixelFormats.Gray8;
                WriteableBitmap wbm = new WriteableBitmap(height, width, 96, 96, format, null);
                wbm.WritePixels(new Int32Rect(0, 0, height, width), imageData, 1*width, 0);
                return wbm;
            }
            else
            {
                return null;
            }
       
        }
