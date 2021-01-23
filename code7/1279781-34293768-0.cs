    class ClassA
	{
		public string NameField;
		
		public string NameProperty { get; set; }
	}
	public class Program
	{
		public static void Main()
		{
			Type t = typeof(ClassA);
			
			foreach(var field in t.GetFields())
			{
				Console.WriteLine(field.Name);
			}
			
			foreach(var prop in t.GetProperties())
			{
				Console.WriteLine(prop.Name);
			}
		}
	}
