    static void Main(string[] args)
    {
    	var path = @"C:\Users\jhochbau\documents\visual studio 2015\Projects\CsvReader\CsvReader\Position_2016_02_25.0415.csv";
    	using (var parsedLines = File.ReadLines(path).Select(line => line.Split(',')).GetEnumerator())
    	{
    		bool more = parsedLines.MoveNext();
    		while (more)
    		{
    			// Initialize
    			var account = parsedLines.Current[0];
    			int vSettleMMSum = 0;
    			int vOpenSum = 0;
    			int vBuySum = 0;
    			int vSellSum = 0;
    			do
    			{
    				// Aggregate
    				vSettleMMSum += int.Parse(parsedLines.Current[10]);
    				vOpenSum += int.Parse(parsedLines.Current[6]);
    				vBuySum += int.Parse(parsedLines.Current[7]);
    				vSellSum += int.Parse(parsedLines.Current[8]);
    				more = parsedLines.MoveNext();
    			}
    			while (more && account == parsedLines.Current[0]);
    			// Consume
    			// Here you have the account and sums, do whatever you like (print etc.)
    		}
    	}
    }
