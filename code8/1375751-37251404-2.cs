    public void output(string folder)
    {
    	string S = "Data" + DateTime.Now.ToString("yyyyMMddHHmm") + ".xml";
    	//Trades.Save(S);
    	string path = Path.Combine(folder, S);
    	Console.WriteLine(path);
    	XDocument f = new XDocument(Trades);
    
    	f.Save(path);
    
    	string[] lines = File.ReadAllLines(path);
    	File.WriteAllLines(path, lines);
    
    	bool isExist = false;
    	using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"H:\Test" + DateTime.Now.ToString("yyMMdd") + ".txt", true))
    	{
    		foreach (string line in lines)
    		{
    			if (line.Contains("CertainData"))
    			{
    				isExist = true;
    			}
    		}
    		if (!isExist)
    		{
    			File.AppendAllText(path, "CertainData" + Environment.NewLine);
    		}
    	}
    }
