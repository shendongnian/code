            private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Initialize Media Capture and Settings Objects, mediaCapture declared global outside this method 
            var mediaCapture = new MediaCapture();
            // Grab all available VideoCapture Devices and find rear device (usually has flash)
            await mediaCapture.InitializeAsync();
            var videoEncodingProperties = MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Vga);
            var videoStorageFile = await KnownFolders.VideosLibrary.CreateFileAsync("tempVideo.mp4", CreationCollisionOption.GenerateUniqueName);
            await mediaCapture.StartRecordToStorageFileAsync(videoEncodingProperties, videoStorageFile);
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            mediaCapture.VideoDeviceController.TorchControl.Enabled = true;
        }
