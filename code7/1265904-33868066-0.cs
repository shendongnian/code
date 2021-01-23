	void Main()
	{
		for (int i = 0; i < 1000000; i++)
		{
			if (i % 2 == 0)
			{
				Task.Run(() =>
				{
					Thread.Sleep(100);
					Console.WriteLine(F.M.ToString());
				});
			}
			else
			{
				F.OtherM = null;
			}
		}
	}
	
	public static class F
	{
		public static M OtherM { get; set; }
		public static M M 
		{ 
			get 
			{ 
				if (OtherM == null)
					OtherM = new M();
				return OtherM;
			} 
		}
	}
	
	public class M { }
	
