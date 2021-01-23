	public async Task BitmapPipelineTest()
	{
		await
			Observable
				.Range(0, 100)
				.Select(_ => new WriteableBitmap(
					800, 600, 96, 96,
					PixelFormats.Bgr24,
					new BitmapPalette(new List<Color>() { new Color() })))
				.SelectMany(x =>
					Observable
						.Start(() =>
						{
							Thread.Sleep(10);
							return new object();
						}));
	}
