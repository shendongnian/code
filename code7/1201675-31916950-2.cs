	public class Item : IEquatable<Item>
	{
		public Item(string name)
		{
			Name = name;
		}
		
		public string Name { get; }
		
		public bool Equals(Item other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(Name, other.Name);
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Item) obj);
		}
		public static bool operator ==(Item left, Item right)
		{
			return Equals(left, right);
		}
		public static bool operator !=(Item left, Item right)
		{
			return !Equals(left, right);
		}
		public override int GetHashCode()
		{
			return (Name != null ? Name.GetHashCode() : 0);
		}
	}
	
