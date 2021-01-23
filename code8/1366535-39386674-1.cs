	public class TitleConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) ? true : base.CanConvertFrom(context, sourceType);
		}
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
				return new Title((string)value);
			return base.ConvertFrom(context, culture, value);
		}
	}
	[TypeConverter(typeof(TitleConverter))]
	public class Title
	{
		...
	}
