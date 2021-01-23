    ImageSurface OutputImage = new ImageSurface (Format.Rgb24, (int)RectangleToCropTo.Width, (int)RectangleToCropTo.Height);
	using (Cairo.Context cr = new Cairo.Context(OutputImage)) {
		cr.SetSource (originalImage, -RectangleToCropTo.X, -RectangleToCropTo.Y);
		cr.Paint ();
	}
