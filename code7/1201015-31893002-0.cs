	void Main()
	{
		var parent = new Parent();
		var child = new Child();
		
		Console.WriteLine(parent.GetName());
		Console.WriteLine(child.GetName());
	}
	
	public class Parent
	{
		public string GetName()
		{
			return this.GetType().FullName;	
		}
	}
	
	public class Child : Parent
	{
	}
	
