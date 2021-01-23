    static void Main(string[] args)
    {
    	var data = new List<List<int>>
    	{
    		new List<int> { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10 },
    		new List<int> { 11, 12, 13, 14, 15 },
    		new List<int> { 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 },
    	};
    	int totalCount = data.Sum(list => list.Count);
    	int pageSize = 6;
    	int pageCount = 1 + (totalCount - 1) / pageSize;
    	for (int pageIndex = 0; pageIndex < pageCount; pageIndex++)
    		Console.WriteLine("Page #{0}: {1}", pageIndex + 1, string.Join(", ", GetPageItems(data, pageSize, pageIndex)));
    	Console.ReadLine();
    }
