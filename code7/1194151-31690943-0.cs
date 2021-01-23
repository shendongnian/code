            private void ResizeImage()
            {
                int iQuality = 70; //define your image quality
                string tempFileName;
    
                using (var stream = new FileStream(filename, FileMode.Open))
                {
                    tempFileName = "resizedImage.jpg";
    
                    long lengthInk = 0;
                    do
                    {
                        var encoder = new JpegBitmapEncoder();
                        encoder.QualityLevel = iQuality;
                        encoder.Frames.Add(BitmapFrame.Create(bitmap));
    
                        using (var stream1 = new FileStream(tempFileName, FileMode.Create))
                        {
                            encoder.Save(stream1);
                        }
    
                        FileInfo fInf = new FileInfo(tempFileName);
                        lengthInk = fInf.Length;
                        iQuality = iQuality - 5; //quality will continue to decrease by 5 until you reach the image size you want
                    } while (lengthInk > 4028); //specify the maximum image size you want to have, for example 4028 for 4KB
                }
            } 
