	public static IObservable<Bitmap> GenerateAsynchronously(Area area)
	{
		int maxIterations = 100;
		double zBorder = 1.0;
		var compute =
			from row in Observable.Range(0, area.Height)
			from col in Observable.Range(0, area.Width)
			from iter in Observable.Start(() =>
			{
				var pixelWidth = (area.MaxReal - area.MinReal) / area.Width;
				double cReal = area.MinReal + col * pixelWidth;
				var pixelHeight = (area.MaxImg - area.MinImg) / area.Height;
				double cImg = area.MinImg + row * pixelHeight;
				double zReal = 0.0;
				double zImg = 0.0;
				var i = 0;
				while (zReal * zReal + zImg * zImg < zBorder && i < maxIterations)
				{
					double zNewReal = zReal * zReal - zImg * zImg;
					double zNewImg = zImg * zReal + zReal * zImg;
					zNewReal = zNewReal + cReal;
					zNewImg = zNewImg + cImg;
					zReal = zNewReal;
					zImg = zNewImg;
					i++;
				}
				return i;
			})
			select new { row, col, iter };
		var query =
			from xs in compute.ToArray()
			from bm in Observable.Start(() =>
			{
				Bitmap bitmap = new Bitmap(area.Width, area.Height);
				foreach (var x in xs)
				{
					bitmap.SetPixel(x.col, x.row, ColorSchema.GetColor(x.iter));
				}
				return bitmap;
			})
			select bm;
		
		return query;
	}
