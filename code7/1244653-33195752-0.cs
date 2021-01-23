	public class Person : IEquatable<Person>
	{
		public Person(string name)
		{
			Name = name;
		}
		public string Name { get; private set; }
		public bool Equals(Person other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Person) obj);
		}
		public override int GetHashCode()
		{
			return (Name != null ? Name.GetHashCode() : 0);
		}
		public static bool operator ==(Person left, Person right)
		{
			return Equals(left, right);
		}
		public static bool operator !=(Person left, Person right)
		{
			return !Equals(left, right);
		}
	}
