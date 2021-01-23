    using (MemoryStream memoryStream = new MemoryStream(yourByteArray))
                {
                    BitmapImage bmpImage = new BitmapImage();
                    bmpImage.BeginInit();
                    bmpImage.StreamSource = memoryStream;
                    bmpImage.EndInit();
                    return bmpImage;
                }
