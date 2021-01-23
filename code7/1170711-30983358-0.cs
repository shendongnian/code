    internal class Program
    {
    	private static void Main(string[] args)
    	{
    		List<string> fileNames = new List<string> {"blablaTobiasbla.txt"};
    		List<string> queries = new List<string> {"Tobias", ".txt"};
    
    		var results = SearchFileNames(fileNames, queries);
    	}
    
    	private static IEnumerable<string> SearchFileNames(IEnumerable<string> fileNames, IEnumerable<string> queries)
    	{
    		return fileNames.Where(fileName => queries.All(fileName.Contains));
    	}
    }
