	public class Item
	{
		public Item(string name)
		{
			Name = name;
		}
		
		public string Name { get; private set; }
	
		public override int GetHashCode()
		{
			return Name != null ? Name.GetHashCode() : 0;
		}
	}
	
