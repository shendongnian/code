	using (var vFReader = new VideoFileReader())
	{
		vFReader.Open("video.mp4");
		for (int i = 0; i < vFReader.FrameCount; i++)
		{
			Bitmap bmpBaseOriginal = vFReader.ReadVideoFrame();
		}
		vFReader.Close();
	}
