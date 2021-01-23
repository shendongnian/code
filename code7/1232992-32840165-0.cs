    List<int> col1 = new List<int>();
    	List<int> col2 = new List<int>();
    	List<int> col3 = new List<int>();
    	
    	using (var reader = new StreamReader(@"C:\users\susingh\desktop\data.txt"))
    	{
    		string line;
    		while (true)
    		{
    			line = reader.ReadLine();
    			if (line==null)
    			{
    				break;
    			}
    			var numArray = line.Split('\t');
    			col1.Add(Int32.Parse(numArray[0]));
    			col2.Add(Int32.Parse(numArray[1]));
    			col3.Add(Int32.Parse(numArray[2]));
    		}
    	}
    	
    	var Foo = col1.OrderByDescending(x=>x);
    	foreach (var element in Foo)
    	{
    		Console.WriteLine (element);
    	}
