		public class OurEnumConverter<T> : CsvHelper.TypeConversion.EnumConverter where T : struct
		{
			public OurEnumConverter(): base(typeof(T))
			{ }
			
			public override string ConvertToString(CsvHelper.TypeConversion.TypeConverterOptions options, object value)
			{
				T result;
				if (Enum.TryParse<T>(value.ToString(), out result))
				{
					return (Convert.ToInt32(result)).ToString();
				}
				return base.ConvertToString(options, value);
				//throw new InvalidCastException(String.Format("Invalid value to EnumConverter. Type: {0} Value: {1}", typeof (T), value));
			}
			public override object ConvertFromString(TypeConverterOptions options, string text)
			{
				int parsedValue;
				//System.Diagnostics.Debug.WriteLine($"{typeof(T).Name} = {text}");
				if (Int32.TryParse(text, out parsedValue))
				{
					return (T)(object)parsedValue;
				}
				return base.ConvertFromString(options, text);
				//throw new InvalidCastException(String.Format("Invalid value to EnumConverter. Type: {0} Value: {1}", typeof(T), text));
			}
			
		}
