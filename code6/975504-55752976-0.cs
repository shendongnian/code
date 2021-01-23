		public static string TrimToString(this StringBuilder sb)
		{
			if (sb == null) return null;
			sb.TrimEnd(); // handles nulle and is very inexpensive, unlike trimstart
			if (sb.Length > 0 && char.IsWhiteSpace(sb[0])) {
				for (int i = 0; i < sb.Length; i++)
					if (!char.IsWhiteSpace(sb[i]))
						return sb.ToString(i);
				return ""; // shouldn't reach here, bec TrimEnd should have caught full whitespace strings, but ...
			}
			return sb.ToString();
		}
