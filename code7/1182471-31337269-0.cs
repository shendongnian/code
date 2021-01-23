	public static class CultureInfoExtensions
	{
		public static IEnumerable<CultureInfo> WithParents(this CultureInfo culture)
		{
			while (true)
			{
				yield return culture;
				if (culture.Parent == culture) yield break;
				culture = culture.Parent;
			}
		}
	}
