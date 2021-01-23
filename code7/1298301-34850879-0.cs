		public bool IsArabic(this string input)
		{
			var isArabic = Regex.Matches(input, "\\p{IsArabic}").Count;
			var isLatin = Regex.Matches(input, "\\p{IsBasicLatin}").Count;
			if (isArabic > isLatin)
				return true;
			return false;
		}
