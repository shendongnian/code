	class Program
	{
		static void Main(string[] args)
		{
			Type fruitType = typeof(Fruits);
			FieldInfo[] fields = fruitType.GetFields();
			foreach (var field in fields)
			{
				Console.WriteLine("Name: {0}", field.Name);
				Console.WriteLine("Value: {0}", field.GetRawConstantValue().ToString());
				var attr = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute)).Cast < System.ComponentModel.DescriptionAttribute>().FirstOrDefault();
				Console.WriteLine("Description: {0}", attr.Description);
				Console.ReadLine();
			}
		}
	}
	public class Fruits
	{
		[Description("The green apples are very green.")]  
		public const string Apples= "Green";
		[Description("Sunkist oranges are very sweet.")]  
		public const string Oranges= "Sunkist";
		[Description("Red grapes are make for wine.")]  
		public const string Grapes= "Red";
	}
