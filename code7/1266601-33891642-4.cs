    void Main()
    {
    	var n = 10000000;
    	var list = Enumerable.Range(0, n).ToList();
    	
    	var array = list.ToArray();
    	
    	Test(TestForeach, list, "foreach - List");
    	Test(TestFor, list, "for - List");
    
    	Test(TestForeach, array, "foreach - Array");
    	Test(TestFor, array, "for - Array");
    	
    	TestSameVariableFor();
    	TestSameVariableForeach();
    }
    
    void TestSameVariableFor()
    {
    	var sum = 0;
    	List<Action> actions = new List<Action>();
    	for (var i = 0; i < 2; i++)
    	{
    		actions.Add(() => sum += i);
    	}
    
    	foreach (var a in actions)
    	{
    		a();
    	}
    
    	Console.WriteLine("For - Sum is {0}", sum);
    }
    
    void TestSameVariableForeach()
    {
    	var sum = 0;
    	List<Action> actions = new List<Action>();
    	foreach (var i in Enumerable.Range(0, 2))
    	{
    		actions.Add(() => sum += i);
    	}
    
    	foreach (var a in actions)
    	{
    		a();
    	}
    
    	Console.WriteLine("Foreach - Sum is {0}", sum);
    }
    
    void Test(Action<List<int>> action, List<int> list, string what)
    {
    	var sw = Stopwatch.StartNew();
    	action(list);
    	sw.Stop();
    	Console.WriteLine("Elapsed {0}, {1}", sw.ElapsedMilliseconds, what);
    	Console.WriteLine();
    }
    
    void Test(Action<int[]> action, int[] list, string what)
    {
    	var sw = Stopwatch.StartNew();
    	action(list);
    	sw.Stop();
    	Console.WriteLine("Elapsed {0}, {1}", sw.ElapsedMilliseconds, what);
    	Console.WriteLine();
    }
    
    void TestFor(List<int> list)
    {
    	long sum = 0;
    
    	var count = list.Count;
    	for (var i = 0; i < count; i++)
    	{
    		sum += i;
    	}
    
    	Console.WriteLine(sum);
    }
    
    void TestForeach(List<int> list)
    {
    	long sum = 0;
    
    	foreach (var i in list)
    	{
    		sum += i;
    	}
    
    	Console.WriteLine(sum);
    }
    
    void TestFor(int[] list)
    {
    	long sum = 0;
    
    	var count = list.Length;
    	for (var i = 0; i < count; i++)
    	{
    		sum += i;
    	}
    
    	Console.WriteLine(sum);
    }
    
    void TestForeach(int[] list)
    {
    	long sum = 0;
    
    	foreach (var i in list)
    	{
    		sum += i;
    	}
    
    	Console.WriteLine(sum);
    }
