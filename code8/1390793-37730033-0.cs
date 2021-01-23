    public class CameraController
    {
        private MediaCapture _mediaCap;
        private bool _isInitialised;
    
        public async Task InitialiseWebCam()
        {
            if (!_isInitialised)
            {
                var settings = ApplicationData.Current.LocalSettings;
                string preferredDeviceName = $"{settings.Values["PreferredDeviceName"]}";
    
                var videoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
                DeviceInformation device = videoDevices.FirstOrDefault(x => x.Name == preferredDeviceName);
                if (device == null)
                    device = videoDevices.FirstOrDefault();
    
                if (device == null)
                    throw new Exception("Cannot find a camera device");
                else
                {
                    //initialize the WebCam via MediaCapture object
                    _mediaCap = new MediaCapture();
                    var initSettings = new MediaCaptureInitializationSettings { VideoDeviceId = device.Id };
                    await _mediaCap.InitializeAsync(initSettings);
                    _mediaCap.Failed += new MediaCaptureFailedEventHandler(MediaCaptureFailed);
    
                    _isInitialised = true;
                }
            }
        }
    
        public async StorageFile RecordVideo(TimeSpan duration)
        {
            if (!_isInitialised)
                await InitialiseWebCam();
    
            StorageFile videoFile = await KnownFolders.VideosLibrary.CreateFileAsync(
                $"video_{DateTime.Now.ToString("yyyyMMddHHmmss")}.mp4", CreationCollisionOption.GenerateUniqueName);
    
            var mediaEncoding = MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Vga);
            await _mediaCap.StartRecordToStorageFileAsync(mediaEncoding, videoFile);
            await Task.Delay(duration);
            await _mediaCap.StopRecordAsync();
    
            return videoFile;
        }
    
        private void MediaCaptureFailed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            //TODO: Implement this
        }
    }
