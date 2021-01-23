    using System.Threading.Tasks;
    using Windows.Storage;
    using Windows.Storage.Streams;
      private async void btn_Click(object sender, RoutedEventArgs e)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/" + "your_image_name.png"));
            string base64image = await _encodeToBase64(file.Path);
        }
     public async Task<string> _encodeToBase64(string filePath)
        {
            string encode = String.Empty;
            if (!string.IsNullOrEmpty(filePath))
            {
                StorageFile file = await StorageFile.GetFileFromPathAsync(filePath);
                IBuffer buffer = await FileIO.ReadBufferAsync(file);
                DataReader reader = DataReader.FromBuffer(buffer);
                byte[] fileContent = new byte[reader.UnconsumedBufferLength];
                reader.ReadBytes(fileContent);
                encode = Convert.ToBase64String(fileContent);
            }
            return encode;
        }
