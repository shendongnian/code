	public string ResizeImage(string sourceFilePath)
	{
		Android.Graphics.Bitmap bmp = Android.Graphics.BitmapFactory.DecodeFile (sourceFilePath);
		string newPath = sourceFilePath.Replace(".bmp", ".png");
		using (var fs = new FileStream (newPath, FileMode.OpenOrCreate)) {
			bmp.Compress (Android.Graphics.Bitmap.CompressFormat.Png, 100, fs);
		}
		return newPath;
	}
