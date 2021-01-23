	public class Tester
	{
		public void Main()
		{
			TestClass.TestHappening += Testing;
			Go();
		}
	
		private void Testing(object sender, EventArgs e)
		{
			Console.WriteLine(TestClass.Test);
			TestClass.TestHappening -= Testing;
		}
	
		private void Go()
		{
			TestClass.Test = true;
		}
	}
