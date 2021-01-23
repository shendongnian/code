    private async void StartPreview()
    {
    previewSink = new Windows.Phone.Media.Capture.MediaCapturePreviewSink();
    // List of supported video preview formats to be used by the default preview format selector.
    var supportedVideoFormats = new List<string> { "nv12", "rgb32" };
    // Find the supported preview format
    var availableMediaStreamProperties = mediaCaptureManager.VideoDeviceController.GetAvailableMediaStreamProperties(
        Windows.Media.Capture.MediaStreamType.VideoPreview)
            .OfType<Windows.Media.MediaProperties.VideoEncodingProperties>()
            .Where(p => p != null 
                && !String.IsNullOrEmpty(p.Subtype) 
                && supportedVideoFormats.Contains(p.Subtype.ToLower()))
            .ToList();
    var previewFormat = availableMediaStreamProperties.FirstOrDefault();
    // Start Preview stream
    await mediaCaptureManager.VideoDeviceController.SetMediaStreamPropertiesAsync(
        Windows.Media.Capture.MediaStreamType.VideoPreview, previewFormat);
    await mediaCaptureManager.StartPreviewToCustomSinkAsync(
        new Windows.Media.MediaProperties.MediaEncodingProfile { Video = previewFormat }, previewSink);
    // Set the source of the VideoBrush used for your preview
    Microsoft.Devices.CameraVideoBrushExtensions.SetSource(viewfinderBrush, previewSink);
    }
