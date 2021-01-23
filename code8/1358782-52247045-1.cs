        public class ZipItem
        {
            public StorageFile motherfile { get; set; }
            public ZipArchiveEntry motherentry { get; set; }
            public string Name { get; set; }
            public string ActualBytes { get; set; }
            public string CompressedBytes { get; set; }
        }
        public List<ZipItem> results;
        public int i = 0;
        private async void  nextimg_Click(object sender, RoutedEventArgs e)
        {
            //Open the zip file. At that point in the program, I previously read
            //all zip files in a hierarchy and stored them in the "results" a 
            //list of ZipItems populated in another method. i points to the
            //image I wish to display in the list. 
            Stream stream = await results[i].motherfile.OpenStreamForReadAsync();
            using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                //look for the entry "i", which is my current slideshow position
                ZipArchiveEntry entry = archive.GetEntry(results[i].motherentry.Name);
                //Open the entry as a stream
                Stream fileStream = entry.Open();
                //Before I read this in memory, I do check for entry.Length to make sure it's not too big. 
                //For simplicity purposes here, I jsut show the "Read it in memory" portion
                var memStream = new MemoryStream();
                await fileStream.CopyToAsync(memStream);
                //Reset the stream position to start
                memStream.Position = 0;
                //Create a BitmapImage from the memStream;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.DecodePixelHeight = (int)ctlImage.Height;
                bitmapImage.DecodePixelWidth = (int)ctlImage.Width;
                //Set the source of the BitmapImage to the memory stream
                bitmapImage.SetSource(memStream.AsRandomAccessStream());
 
                //Set the Image.Source to the BitmapImage
                ctlImage.Source = bitmapImage;
                }
            }
        }
