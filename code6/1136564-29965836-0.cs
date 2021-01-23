	void Main()
	{
		do
		{
			Calc(Util.ReadLine()).Dump();
		}
		while (true);
	}
	
	string Calc(string str)
	{
		using (System.Net.WebClient wc = new System.Net.WebClient())
		{
			return "from WEBAPI....";		
		}	
	}
