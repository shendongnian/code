    		static async Task slowly(string sen)
		{
			await Task.Run(() =>
			{
				for (int j = 0; j < sen.Length - 1; j++)
				{
					Console.Write(sen[j]);
					System.Threading.Thread.Sleep(100);
				}
				Console.WriteLine(sen[sen.Length - 1]);
				System.Threading.Thread.Sleep(100);
			});
		}
		public static void Main(string[] args)
		{
			
			var slowlyTask = slowly("hello world");
			//do stuff while writing to the screen
			var i = 0;
			i++;
			//wait for text to finish writing before doing somethign else
			slowlyTask.Wait();
			//do another something after it's done;
			var newSlowlyTask = slowly("goodbye");
			newSlowlyTask.Wait();
		}
