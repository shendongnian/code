    public static class ArrayHelper 
    {
    	public static List<List<T>> ToList<T>(this T[,] array)
    	{
    		var result = new List<List<T>>();
            var lengthX = array.GetLength(0);
            var lengthY = array.GetLength(1);
    		
            // the reason why we get lengths of dimensions before looping through
            // is because we would like to use `List<T>(int length)` overload
            // this will prevent constant resizing of its underlying array and improve performance
    		for(int i = 0; i < lengthX  i++)			
    		{
    			var listToAdd = new List<T>(lengthY);
    			
    			for(int i2 = 0; i2 < lengthY; i2++)
    			{
    				listToAdd.Add(array[i, i2]);
    			}
    			
    			result.Add(listToAdd);
    		}		
    		
    		return result;
    	}		
    }
