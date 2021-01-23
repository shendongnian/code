    List<string> list1 = new List<string>() { "A", "B", "C", "D" };
    List<string> listResult = new List<string>();
    
    for (int i = 0; i < list1.Count; i++)
    {
    	for (int k = 0; k < list1.Count; k++)
    	{
    		if (k <= i)
    		{
    			Console.WriteLine("{0} against {1} - Skip", list1[i], list1[k]);
    		}
    		else
    		{
    			Console.WriteLine("{0} against {1} - Good", list1[i], list1[k]);
    			listResult.Add(list1[i] + list1[k]);
    		}
    	}
    }
