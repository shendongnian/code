    void Main()
    {
    	var items = new int [] {100,50,10};
    	var dict = new Dictionary<int,int>();
    	var test = Enumerable.Range(1,10000);
    	foreach (var t in test)
    	{
    		var result = SelectItem(items);
    		if (!dict.ContainsKey(result))
    		{
    			dict.Add(result,0);
    		}
    		dict[result]++;
    	}
    	
    	foreach (var d in dict.Keys)
    	{
    		Console.WriteLine("{0} - {1}",d,dict[d]);
    	}
    
    	
    }
    
    private static Random rand = new Random(DateTime.Now.Millisecond);
    private int SelectItem(IEnumerable<int> numbers)
    {
    	var num = rand.Next(1,numbers.Sum());
    	var list = numbers.OrderBy(n=>n)
    		.SelectMany(n=> Enumerable.Range(1,n).Select(rr=>n)).ToList();
    	//list.GroupBy(x=>x).Dump();
    	//Console.WriteLine("Rand num = {0}, selected num = {1}",num,ret);
    	return  list[num-1];;
    }
