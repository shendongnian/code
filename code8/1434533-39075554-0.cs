    public class QueryResult
    {
    	public int StartUnit { get; set; }
    	public int LengthUnit { get; set; }
    }
	var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	
	var queryResult = new QueryResult[]
	{
		new QueryResult { StartUnit = 1, LengthUnit = 1 },
		new QueryResult { StartUnit = 3, LengthUnit = 2 },
		new QueryResult { StartUnit = 7, LengthUnit = 1 },
	};
	
	var taken = new List<int>();
	
	taken.AddRange(queryResult.SelectMany(q => (input.Skip(q.StartUnit - 1).Take(q.LengthUnit))));
	
	Console.WriteLine("Taken: {0}", string.Join(",", taken));
	
	var notTaken = input.Except(taken);
	
	Console.WriteLine("Not taken: {0}", string.Join(",", notTaken));
	
