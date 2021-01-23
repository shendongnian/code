    var dict = new Dictionary<string, Func<int, int, int>> () {
		{ "add", AddFunc },
		{ "minus", MinusFunc }
	};
		
    public static int AddFunc(int arg1, int arg2)
    {
        return arg1 + arg2;
    }
    public static int MinusFunc(int arg1, int arg2)
    {
        return arg1 - arg2;
    }
