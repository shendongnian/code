	public class ImageItem
	{
		public Uri Image { get; set; }
		private BitmapSource _Source;
		public BitmapSource Source
		{
			get
			{
				try
				{
					if (_Source == null) _Source = new BitmapImage(Image);//lazy loading
				}
				catch (Exception)
				{
					_Source = null;
				}
				return _Source;
			}
		}
	}
