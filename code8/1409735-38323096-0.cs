    [SQLiteFunction(FuncType = FunctionType.Collation, Name = "NORMALIZEDCI")]
    public class SQLiteNormalizedComparer : SQLiteFunction 
    {
		private static string RemoveDiacritics(string text)
		{
			var normalizedString = text.Normalize(NormalizationForm.FormD);
			var stringBuilder = new StringBuilder();
			foreach (var c in normalizedString)
			{
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark)
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
		}
        public override int Compare(string x, string y) 
        {             
            return string.Compare(RemoveDiacritics(x), RemoveDiacritics(y), StringComparison.OrdinalIgnoreCase);
        }
    }
