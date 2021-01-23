    class Writer
	{
		public void WriteLine(string myText)
		{
			for (int i = 0; i < myText.Length; i++)
			{
				if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
				{
					Console.Write(myText.Substring(i, myText.Length - i));
					break;
				}
				Console.Write(myText[i]);
				System.Threading.Thread.Sleep(pauseTime);
			}
			Console.WriteLine("");
		}
	}
