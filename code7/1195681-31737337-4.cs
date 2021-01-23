	public class Code
	{
		private Match _match = null;
		public Code(string raw)
		{
			_match = Regex.Match(raw, @"^([A-Z]*)([^0-9]*)(\d+)(.*)$");
		}
		public string Prefix { get { return _match.Groups[1].Value; } }
		public string Separator { get { return _match.Groups[2].Value; } }
		public int Number { get { return int.Parse(_match.Groups[3].Value); } }
		public string Suffix { get { return _match.Groups[4].Value; } }
		public override string ToString()
		{
			return String.Format("{0}/{1:00000}{2}", this.Prefix, this.Number, this.Suffix);
		}
	}
