    public struct QueryResult
    {
    	public readonly int Index;
    	public readonly dynamic Data;
    	internal QueryResult(int index, dynamic data)
    	{
    		Index = index;
    		Data = data;
    	}
    }
