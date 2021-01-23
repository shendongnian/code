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
			// Add a simple green filter effect to the SoftwareBitmap
            EditPixels(previewFrame);
        }
    }
    private unsafe void EditPixels(SoftwareBitmap bitmap)
	{
		// Effect is hard-coded to operate on BGRA8 format only
		if (bitmap.BitmapPixelFormat == BitmapPixelFormat.Bgra8)
		{
			// In BGRA8 format, each pixel is defined by 4 bytes
			const int BYTES_PER_PIXEL = 4;
			using (var buffer = bitmap.LockBuffer(BitmapBufferAccessMode.ReadWrite))
			using (var reference = buffer.CreateReference())
			{
				// Get a pointer to the pixel buffer
				byte* data;
				uint capacity;
				((IMemoryBufferByteAccess)reference).GetBuffer(out data, out capacity);
				// Get information about the BitmapBuffer
				var desc = buffer.GetPlaneDescription(0);
				// Iterate over all pixels
				for (uint row = 0; row < desc.Height; row++)
				{
					for (uint col = 0; col < desc.Width; col++)
					{
						// Index of the current pixel in the buffer (defined by the next 4 bytes, BGRA8)
						var currPixel = desc.StartIndex + desc.Stride * row + BYTES_PER_PIXEL * col;
						// Read the current pixel information into b,g,r channels (leave out alpha channel)
						var b = data[currPixel + 0]; // Blue
						var g = data[currPixel + 1]; // Green
						var r = data[currPixel + 2]; // Red
						// Boost the green channel, leave the other two untouched
						data[currPixel + 0] = b;
						data[currPixel + 1] = (byte)Math.Min(g + 80, 255);
						data[currPixel + 2] = r;
					}
				}
			}
		}
	}
