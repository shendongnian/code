         private async void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            //Start the device 
            try
            {
                _mediaCapture = new MediaCapture();
                _mediaCapture.RecordLimitationExceeded += MediaCapture_RecordLimitationExceeded;
                _mediaCapture.Failed += MediaCapture_Failed;
                await _mediaCapture.InitializeAsync();
            }
            catch (UnauthorizedAccessException ex)
            {
                (new MessageDialog("Set the permission to use the webcam")).ShowAsync();                
            }
            catch (Exception ex)
            {
                (new MessageDialog("Can't initialize the webcam !")).ShowAsync();                
            }
            //Start the preview 
            if (_mediaCapture != null)
            {
                try
                {
                    PreviewElement.Source = _mediaCapture;
                    await _mediaCapture.StartPreviewAsync();
                }
                catch (Exception ex)
                {
                    (new MessageDialog("Something went wrong !")).ShowAsync();
                }
            }
        }
        private async void MediaCapture_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => (new MessageDialog("Media capture failed")).ShowAsync());
        }
        private async void MediaCapture_RecordLimitationExceeded(MediaCapture sender)
        {
            await _mediaCapture.StopRecordAsync();
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => (new MessageDialog("Record limitation exceeded")).ShowAsync());
        }
