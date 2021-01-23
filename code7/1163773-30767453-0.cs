	public class SynonymAttribute : Attribute
	{
		private readonly string _name;
		public SynonymAttribute(string name)
		{
			_name = name;
		}
		public string Name
		{
			get
			{
				return _name;
			}
		}
	}
