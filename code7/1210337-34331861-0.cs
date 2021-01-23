    FileStream fileStream = new FileStream(@"C:\QRcodes\IMG_9540.CR2", FileMode.Open);
            using (MagickImage magickImage = new MagickImage(fileStream))
            {
                byte[] imageBytes = magickImage.ToByteArray();
                
                Console.WriteLine("bytes in image: " + imageBytes.Length);
                Console.ReadKey();
            }
