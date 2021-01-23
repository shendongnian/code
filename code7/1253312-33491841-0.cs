	public struct DecimalInfo
	{
		public int Scale;
		public int Length;
		public override string ToString()
		{
			return string.Format("Scale={0}, Length={1}", Scale, Length);
		}
	}
	public static class Extensions
	{
		public static DecimalInfo GetInfo(this decimal value)
		{
			string decStr = value.ToString().Replace("-", "");
			int decpos = decStr.IndexOf(".");
			int length = decStr.Length - (decpos < 0 ? 0 : 1);
			int scale = decpos < 0 ? 0 : length - decpos;
			return new DecimalInfo { Scale = scale, Length = length };
		}
	}
