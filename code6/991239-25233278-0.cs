    void Main()
    {
    	var arr = new[] { 5 };
    	var coll = new ReadOnlyCollection<int>(arr);
    	Console.WriteLine (coll[0]); // 5
    	arr[0] = 1;
    	Console.WriteLine (coll[0]); // 1
    }
    void Main()
    {
    	var arr = new[] { 5 };
    	var arr2 = new int[] { 0 };
    	Array.Copy(arr, arr2, arr.Length);
    	var coll = new ReadOnlyCollection<int>(arr2);
    	Console.WriteLine (coll[0]); // 5
    	arr[0] = 1;
    	Console.WriteLine (coll[0]); // 5
    }
