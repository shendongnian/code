	public class ValueFormatter
	{
		public string Format(object value)
		{       	
			return Format(value as dynamic);
		}
	
		private string Format(DateTime date)
		{
			return date.ToString("MM/dd/yyyy");
		}
		
		private string Format(float floatData)
		{
			return floatData.ToString(CultureInfo.CreateSpecificCulture("de-DE"));
		}
		
		// ...
	}
