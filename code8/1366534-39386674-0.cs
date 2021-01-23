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
		// optional
		public override bool IsValid(ITypeDescriptorContext context, object value)
		{
			var title = value as Title;
			return title != null ? title.YourCustomValidation() : base.IsValid(context, value);
		}
	}
	[TypeConverter(typeof(TitleConverter))]
	public class Title
	{
		...
	}
