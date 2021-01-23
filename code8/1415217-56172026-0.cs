    public static int[] Rotate(int[] elements, int numberOfRotations)
    {
    	IEnumerable<int> newEnd = elements.Take(numberOfRotations);
    	IEnumerable<int> newBegin = elements.Skip(numberOfRotations);
    	return newBegin.Union(newEnd).ToArray();
    }
