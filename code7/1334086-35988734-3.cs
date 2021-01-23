	namespace ConsoleApplication1
	{
		class Program
		{
			static void H()
			{
				MyDelegate.Program.Calculate y = (x, w) => 1;
			}
		}
	}
	
	namespace MyDelegate
	{   
		class Program
		{
			public delegate int Calculate(int value1, int value2);
			static void Main(string[] args)
			{
			}
		}
	}
	
