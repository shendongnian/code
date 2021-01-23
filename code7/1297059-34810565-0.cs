     public async Task ReadFile() {
          string filePath = @"SampleFile.txt";
    
          if (File.Exists(filePath) == false) {
            MessageBox.Show(filePath + " not found", "File Error", MessageBoxButton.OK);
          } else {
            try {
              string text = await ReadText(filePath);
              txtContents.Text = text;
            } catch (Exception ex) {
              Debug.WriteLine(ex.Message);
            }
          }
        }
    
        private async Task<string> ReadText(string filePath) {
    
          using (FileStream sourceStream = new FileStream(filePath,
              FileMode.Open, FileAccess.Read, FileShare.Read,
              bufferSize: 4096, useAsync: true)) {
            StringBuilder sb = new StringBuilder();
    
            byte[] buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0) {
              string text = Encoding.Unicode.GetString(buffer, 0, numRead);
              sb.Append(text);
            }
    
            return sb.ToString();
          }
    
        }
