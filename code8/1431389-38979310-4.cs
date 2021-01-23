	public interface IPerson
	{
		string Name { get; }
	}
	public abstract class Person : IPerson
	{
		protected Person (string name)
		{
			Name = name;
		}
		public string Name { get; }
	}
	public class Adult : Person
	{
		public Adult(string name) : base(name) { }
	}
	public class Child : Person
	{
		public Child(string name, int age) : base(name)
		{
			Age = age
		}
		public int Age { get; }
	}
