	public class CustomColor : MarkupExtension
	{
		[ConstructorArgument("Key")]
		public object Key { get; set; }
		public CustomColor()
		{
		}
		public CustomColor(object key)
		{
			this.Key = key;
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			try
			{
				var color = (Color)ColorConverter.ConvertFromString(this.Key.ToString()); 
				return new SolidColorBrush(color);
			}
			catch
			{
				return new SolidColorBrush(Colors.Transparent);
			}
		}
	}
