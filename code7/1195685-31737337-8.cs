	public class Code
	{
		public Code(string raw)
		{
			if (raw == "SUITE FIVE")
			{
				this.Prefix = raw;
				this.Separator = "/";
				this.Number = 0;
				this.Suffix = "";
			}
			else
			{
				var match = Regex.Match(raw, @"^([A-Z]*)([^0-9]*)(\d+)(.*)$");
				this.Prefix = match.Groups[1].Value;
				this.Separator = match.Groups[2].Value;
				this.Number = int.Parse(match.Groups[3].Value);
				this.Suffix = match.Groups[4].Value;
			}
		}
		public string Prefix { get; private set; }
		public string Separator { get; private set; }
		public int Number { get; private set; }
		public string Suffix { get; private set; }
		public override string ToString()
		{
			return String.Format("{0}/{1:00000}{2}", this.Prefix, this.Number, this.Suffix);
		}
	}
