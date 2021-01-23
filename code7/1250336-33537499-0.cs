        private async void button_Click(object sender, RoutedEventArgs e)
        {
            _mediaCapture = new MediaCapture();
            await _mediaCapture.InitializeAsync();
            mediaElement.Source = _mediaCapture;
            await _mediaCapture.StartPreviewAsync();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private async void Timer_Tick(object sender, object e)
        {
            var previewProperties = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview) as VideoEncodingProperties;
            var videoFrame = new VideoFrame(BitmapPixelFormat.Bgra8, (int)previewProperties.Width, (int)previewProperties.Height);
            var frame = await _mediaCapture.GetPreviewFrameAsync(videoFrame);
            SoftwareBitmap frameBitmap = frame.SoftwareBitmap;
            WriteableBitmap bitmap = new WriteableBitmap(frameBitmap.PixelWidth, frameBitmap.PixelHeight);
            frameBitmap.CopyToBuffer(bitmap.PixelBuffer);
            Debug.WriteLine("done");
        }
