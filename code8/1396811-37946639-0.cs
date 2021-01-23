    [ValueConversion(typeof(Uri), typeof(BitmapImage))]
	public class ImageConverter : IValueConverter
	{
		public ImageConverter()
		{
		}
		public object Convert(object value, Type targetType,
						  object parameter, CultureInfo culture)
		{
			try
			{
				if(value == null)
				{
					return null;
				}
				var image = new BitmapImage();
				image.BeginInit();
				image.UriSource = value is Uri ? (Uri)value : new Uri(value.ToString());
				image.CacheOption = BitmapCacheOption.OnLoad;
				image.EndInit();
				return image;				
			}
			catch
			{
				return null;
			}
		}
		public object ConvertBack(object value, Type targetType,
								  object parameter, CultureInfo culture)
		{
			throw new NotSupportedException("Convert back function is not supported");
		}
	}
