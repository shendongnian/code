	private async Task GetPreviewFrameAsSoftwareBitmapAsync()
	{
		// Get information about the preview
		var previewProperties = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview) as VideoEncodingProperties;
		// Create the video frame to request a SoftwareBitmap preview frame
		var videoFrame = new VideoFrame(BitmapPixelFormat.Bgra8, (int)previewProperties.Width, (int)previewProperties.Height);
		// Capture the preview frame
		using (var currentFrame = await _mediaCapture.GetPreviewFrameAsync(videoFrame))
		{
			// Collect the resulting frame
			SoftwareBitmap previewFrame = currentFrame.SoftwareBitmap;
			// Copy the SoftwareBitmap to a WriteableBitmap to display it to the user
			var wb = new WriteableBitmap(previewFrame.PixelWidth, previewFrame.PixelHeight);
			previewFrame.CopyToBuffer(wb.PixelBuffer);
			// Display it in the Image control
			PreviewFrameImage.Source = wb;
        }
    }
