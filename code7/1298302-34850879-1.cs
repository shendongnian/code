		public bool IsArabic(this string input)
		{
			var isArabic = Regex.Matches(input, "\\p{IsArabic}");
			var isLatin = Regex.Matches(input, "\\p{IsBasicLatin}");
            if (isArabic == null)
                return false;
            if (isLatin == null)
                return true; //suggest that there is no another character types
			if (isArabic.Count > isLatin.Count)
				return true;
			return false;
		}
