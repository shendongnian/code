	/// <summary>
	/// Records an MP4 video to a StorageFile and adds rotation metadata to it
	/// </summary>
	/// <returns></returns>
	private async Task StartRecordingAsync()
	{
		try
		{
			// Create storage file in Pictures Library
			var videoFile = await KnownFolders.PicturesLibrary.CreateFileAsync("SimpleVideo.mp4", CreationCollisionOption.GenerateUniqueName);
			var encodingProfile = MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Auto);
			// Calculate rotation angle, taking mirroring into account if necessary
			var rotationAngle = 360 - ConvertDeviceOrientationToDegrees(GetCameraOrientation());
			encodingProfile.Video.Properties.Add(RotationKey, PropertyValue.CreateInt32(rotationAngle));
			Debug.WriteLine("Starting recording...");
			await _mediaCapture.StartRecordToStorageFileAsync(encodingProfile, videoFile);
			_isRecording = true;
			Debug.WriteLine("Started recording!");
		}
		catch (Exception ex)
		{
			// File I/O errors are reported as exceptions
			Debug.WriteLine("Exception when starting video recording: {0}", ex.ToString());
		}
	}
