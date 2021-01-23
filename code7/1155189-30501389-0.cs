	using System;
	public class Program
	{
		public static void Main()
		{
			int[] mosquitoHistory = new int[10];
			for (int seconds = 0; seconds < 9; seconds++)
			{
				int matureMosquitos = (seconds-2 >= 0 ? mosquitoHistory[seconds-2] : 0);
				mosquitoHistory[seconds] = (seconds-1 >= 0 ? mosquitoHistory[seconds-1] : 1) + matureMosquitos;					
				Console.WriteLine(mosquitoHistory[seconds]); 
                Threading.Thread.Sleep(1000);
			}
		}
	}
