	/// <summary>
	/// Takes a photo to a StorageFile and adds rotation metadata to it
	/// </summary>
	/// <returns></returns>
	private async Task TakePhotoAsync()
	{
		// While taking a photo, keep the video button enabled only if the camera supports simultaneously taking pictures and recording video
		VideoButton.IsEnabled = _mediaCapture.MediaCaptureSettings.ConcurrentRecordAndPhotoSupported;
		// Make the button invisible if it's disabled, so it's obvious it cannot be interacted with
		VideoButton.Opacity = VideoButton.IsEnabled ? 1 : 0;
		var stream = new InMemoryRandomAccessStream();
		try
		{
			Debug.WriteLine("Taking photo...");
			await _mediaCapture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), stream);
			Debug.WriteLine("Photo taken!");
			var photoOrientation = ConvertOrientationToPhotoOrientation(GetCameraOrientation());
			await ReencodeAndSavePhotoAsync(stream, photoOrientation);
		}
		catch (Exception ex)
		{
			// File I/O errors are reported as exceptions
			Debug.WriteLine("Exception when taking a photo: {0}", ex.ToString());
		}
	}
