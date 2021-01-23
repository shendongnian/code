		static string EncodeNonAsciiCharacters(string value)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in value)
			{
				string encodedValue = "&#" + ((int)c).ToString("d4"); // <------- changed
				sb.Append(encodedValue);
			}
			return sb.ToString();
		}
