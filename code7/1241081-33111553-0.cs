	private static async void changeImage(Molecule molecule)
	{
		Molecule.Reaction++;    // Used as Working/Loading status here
        var atoms = molecule.Atoms;
		if (atoms > 5) atoms = 5;
		var stream = await GetStream("Assets/Images/" + atoms + ".png");
		var decoder = await BitmapDecoder.CreateAsync(stream); 
		var pixelData = await decoder.GetPixelDataAsync();
		var data = pixelData.DetachPixelData();	// Finally something where I can get my pixels
		
		var wb = new WriteableBitmap(16, 16);
		//wb.SetSource(stream);     // Get pixel not working so I dont need this
		
		for(int y = 0; y < decoder.PixelHeight; y++)
		{
			for(int x = 0; x < decoder.PixelWidth; x++)
			{
				// var rgba = wb.GetPixel(x, y);	// This is not working, only returnning empty pixels (A:0, R:0, G:0, B:0)
				
				// Get RGBA value of pixel
				var rgba = new Color {
					R = data[x * 4 + y * decoder.PixelWidth * 4 + 0],
					G = data[x * 4 + y * decoder.PixelWidth * 4 + 1],
					B = data[x * 4 + y * decoder.PixelWidth * 4 + 2],
					A = data[x * 4 + y * decoder.PixelWidth * 4 + 3]
				};
				// Array can't have index -1 and -1 is for gray what is default
				if (molecule.Owner != -1)
				{
					// Colorize pixel
					var z = ((rgba.R + rgba.G + rgba.B) / 3.0) / 256;
					rgba.R = Convert.ToByte(z * Settings.Colors[molecule.Owner].Item1.Color.R);
					rgba.G = Convert.ToByte(z * Settings.Colors[molecule.Owner].Item1.Color.G);
					rgba.B = Convert.ToByte(z * Settings.Colors[molecule.Owner].Item1.Color.B);
					data[x * 4 + y * decoder.PixelWidth * 4 + 0] = rgba.R;
					data[x * 4 + y * decoder.PixelWidth * 4 + 1] = rgba.G;
					data[x * 4 + y * decoder.PixelWidth * 4 + 2] = rgba.B;
				}
				wb.SetPixel(x, y, rgba); // I tried to connect byte[] and WriteAbleBitmap via stream but Failed so I'm using this
			}
		}
		
		if (atoms == molecule.Atoms)	// Because it's async method so If value is already different don't change it to old picture
		{
			molecule.parent.Content = new Image();
			(molecule.parent.Content as Image).Source = wb;
			(molecule.parent.Content as Image).Width = 24;
			(molecule.parent.Content as Image).Height = 24;
		}
		Molecule.Reaction--;	// done changing picture
	}
	internal static async Task<IRandomAccessStream> GetStream(string relativePath)
	{
		var storageFile = await Package.Current.InstalledLocation.GetFileAsync(relativePath.Replace('/', '\\'));
		var stream = await storageFile.OpenReadAsync();
		return stream;
	}
