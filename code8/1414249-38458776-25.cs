	public class ImageItem
	{
		public Uri URI{ get; set; }
		private BitmapSource _Source;
		public BitmapSource Source
		{
			get
			{
				try
				{
					if (_Source == null) _Source = new BitmapImage(URI);//lazy loading
				}
				catch (Exception)
				{
					_Source = null;
				}
				return _Source;
			}
		}
		public void Save(string filename)
		{
			var img = BitmapFrame.Create(Source);
			var encoder = new JpegBitmapEncoder();
			encoder.Frames.Add(img);
			using(var saveStream = System.IO.File.OpenWrite(filename))
				encoder.Save(saveStream)
			
		}
	}
