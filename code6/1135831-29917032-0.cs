	public class Choobakka
	{
	    public string Name { get; set; }
		[XmlIgnore]
	    public VariableList<Item> Stuff { get; set; } // we do not serialize this
		[XmlArray("Stuff")]
		public Item[] _Stuff // but this
		{
			get
			{
                // get Item[] from Stuff property somehow
                // ...
                // as test
				return new Item[] {new Item() { Name = "1", Value = "111"}, new Item() { Name = "2", Value = "222"}};
			}
			set
			{
                // set Stuff property from Item[] somehow
                // ...
			}
		}
	}
