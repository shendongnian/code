	using System;
	public static MyStringExtentions
	{
		public static string After(this string orig, char delimiter)
		{
			int p = orig.indexOf(delimiter);
			if (p == -1)
				return string.Empty;
			else
				return orig.Substring(p + 1);
		}
	}
