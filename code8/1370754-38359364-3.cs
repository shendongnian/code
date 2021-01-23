	using System;
	using System.Threading.Tasks;
	namespace ConsoleApp
	{
		class ConsoleApp
		{
			public static void Beep()
			{
				// make sound
			}
			public static void PrintNumber(int number)
			{
				Console.WriteLine(number);
			}
			public static void Main(string[] args)
			{
				var printTask = Task.Factory.StartNew(
					() =>
					{
						for (int i = 0; i < 10; ++i)
							PrintNumber(i);
					});
				var beepTask = Task.Factory.StartNew(
					() =>
					{
						for (int i = 10; i > 0; --i)
							Beep();
					});
				printTask.Wait();
				beepTask.Wait();
			}
		}
	}
