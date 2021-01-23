	public class LeadingSpaceTypeConverter : DefaultTypeConverter {
		public override string ConvertToString( TypeConverterOptions options, object value ) {
			if (value == null ) {
				return String.Empty;
			}
			return String.Concat(" ", value.ToString());
		}
	}
