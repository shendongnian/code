    void Main()
    {
    	//This code proves that the object is being modified.
       Thing prevRow = null;
    	foreach (var curRow in Rows(new List<int>() { 1, 2, 3 }))
        {
    		Console.WriteLine(curRow);
    		Console.WriteLine(prevRow);
    		prevRow = curRow;
    	}
    	
    	//Because the object is modified instead of a new object being returned,
        // this code does something unexpected; it returns the same object 3
        // times! Instead of three unique objects representing the values 1, 2, 3.
    	var rowsAsList = Rows(new List<int>() { 1, 2, 3 }).ToList();
    	foreach (var curRow in rowsAsList)
    	{
    		Console.WriteLine(curRow);
    	}
    }
    
    public class Thing
    {
    	public int i;
    }
    
    IEnumerable<Thing> Rows(List<int> simpletable)
    {
    	var sqlRow = new Thing() {i=-1};
    	foreach (int i in simpletable)
    	{
    		sqlRow.i = i;
    		yield return sqlRow;
    	}
    }
