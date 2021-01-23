	public static void Main()
	{
		string[] test = new string[5];
			
		for(int x = 0; x < test.Length; x++)
		{
		    test[x] = "#" + (x + 1) + " element";
		    Console.WriteLine(test[x]);
		}
		
		Console.WriteLine();
		
		RemoveAt(ref test, 3);
		// Or RemoveRange(ref test, 3, 1);
		for(int x = 0; x < test.Length; x++)
		{
		    Console.WriteLine(test[x]);
		}
	}
	
	public static void RemoveAt<T>(ref T[] array, int index)
	{
		RemoveRange(ref array, index, 1);
	}
	public static void RemoveRange<T>(ref T[] array, int start, int count)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		
		if (start < 0 || start > array.Length)
		{
			throw new ArgumentOutOfRangeException("start");
		}
		
		if (count < 0 || start + count > array.Length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (count == 0)
		{
			return;
		}
			
		T[] orig = array;
		array = new T[orig.Length - count];
		Array.Copy(orig, 0, array, 0, start);
		Array.Copy(orig, start + count, array, start, array.Length - start);
	}
