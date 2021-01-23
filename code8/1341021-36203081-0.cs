	public class SomeModel
	{
		public List<SomeOtherType> NumSetsInRubbers { get; set; }
		public SomeModel(int numRubbers, int numSetsInRubbers)
		{
            // this is just a flimsy example to show how you can create a list of nodes. Notet hat you could nest nodes in other node types but it was hard to gleam from your example how you actually had the code setup
			this.NumSetsInRubbers = new List<SomeOtherType>(numRubbers*numSetsInRubbers);
			for(int i = 0; i < NumSetsInRubbers.Count; i++)
				NumSetsInRubbers[i] = new SomeOtherType();
		}
	}
	public class SomeOtherType
	{
		public int Match { get; set; }
	}
