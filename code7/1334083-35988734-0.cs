	namespace ConsoleApplication1
	{
		class Program
		{
			static void H()
			{
				MyDelegate.Calculate y = (x, w) => 1;
			}
		}
	}
	
	namespace MyDelegate
	{
		public delegate int Calculate(int value1, int value2);
		class Program
		{
			static void Main(string[] args)
			{
			}
		}
	}
	
