    string sFileName = @"D:\veetel.txt";
    	string[] alap = File.ReadAllLines(sFileName);
    	for(int i=0; i<alap.Length; i+=2)
    	{
     	    int one = 0;
		    int two = 0;
    		string[] twolines = alap.Skip(i).Take(2).ToArray();
    		int pos = twolines[1].IndexOf("/");
    		if(pos>-1)
    		{
     			Int32.TryParse(twolines[1].Substring(0,pos)
                         .Replace("#", "").Trim(), out one);
                Int32.TryParse(twolines[1].Substring(pos+1,2)
                         .Replace("#","").Trim(), out two);
    		}
    		Console.WriteLine("{0}\t{1}\t{2}", 
                          twolines[1].Substring(0,8), one, two);
    	}
