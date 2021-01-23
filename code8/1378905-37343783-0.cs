     internal class Program
    	{
    		public class MyClass
    		{
			public int Property
			{
				get;
				set;
			}
			public string Property2
			{
				get;
				set;
			}
		}
		private static void Main(string[] args)
		{
			Program.MyClass expr_06 = new Program.MyClass();
			expr_06.Property = 1;
			expr_06.Property2 = "test";
			Program.MyClass expr_20 = new Program.MyClass();
			expr_20.Property = 1;
			expr_20.Property2 = "test";
		}
	}
