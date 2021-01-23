    delegate int ParamsDelegate(params int[] args);
    ...
	var test = new { 
		Sum = new ParamsDelegate(x => x.Sum())
	};
	
	int sum = (int)test.Sum.DynamicInvoke(new [] { new [] {1, 2, 3} }); // 6
