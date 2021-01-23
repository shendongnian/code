            var image = bitmapImage.ImageTo24bpp();
            //convert image to bytes[]
            ImageConverter imgCon = new ImageConverter();
            var bytes=  (byte[])imgCon.ConvertTo(image, typeof(byte[]));
            //save to filename
            File.WriteAllBytes(fname,bytes);
