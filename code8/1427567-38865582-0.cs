        private async void WriteData()
        {
            var removableDevices = KnownFolders.RemovableDevices;
            var externalDrives = await removableDevices.GetFoldersAsync();
            var drive0 = externalDrives[0];
            var testFolder = await drive0.CreateFolderAsync("Test");
            var testFile = await testFolder.CreateFileAsync("Test.jpg");
            var byteArray = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            using (var sourceStream = new MemoryStream(byteArray).AsRandomAccessStream())
            {
                using (var destinationStream = (await testFile.OpenAsync(FileAccessMode.ReadWrite)).GetOutputStreamAt(0))
                {
                    await RandomAccessStream.CopyAndCloseAsync(sourceStream, destinationStream);
                }
            }
        }
 
