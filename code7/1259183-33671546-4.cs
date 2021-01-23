	public enum SomeEnum
	{
		Alpha,
		Bravo
	}
	public class User
	{
		public User(string name)
		{
			this.Name = name;
		}
		public string Name { get; private set; }
	}
	public class CustomClass
	{
		public CustomClass(string notation)
		{
			this.Notation = notation;
		}
		public string Notation { get; private set; }
	}
