    public async Task CallerAsync()
    {
    	int[] numbers = new int[] { 1, 2, 3 };
    	Dictionary<int, string> dictionary = await ConvertToDictionaryAsync(numbers);
    }
    
    public async Task<Dictionary<int, string>> ConvertToDictionaryAsync(int[] numbers)
    {
    	var dict = new Dictionary<int, string>();
    	
    	for (int i = 0; i < numbers.Length; i++)
    	{
    		var n = numbers[i];
    		dict[n] = await DoSomethingReturnString(n);
    	}
    
    	return dict;
    }
