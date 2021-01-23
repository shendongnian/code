    public class ReadOnlyTwoDimensionalArray<T>
    {
    	private T[,] _arr;
    	public ReadOnlyTwoDimensionalArray(T[,] arr)
    	{
    		_arr = arr;
    	}
    	public T this[int index1, int index2]
    	{
    		get {return _arr[index1, index2];}
    	}
    }
