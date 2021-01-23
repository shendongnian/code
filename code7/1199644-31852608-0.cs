    void Main()
    {
    	int[] sourceCollection = new [] {1,2,3,4,5,6,7} ;
    	
    	var result = CopyArrayValues(sourceCollection, 2);
    	result.Dump();
    }
    //create a new 2d array
    T[,] CopyArrayValues<T>(T[] DataSource, int SecondLength)
    {
        //Initialize the new array
    	var Target = new T[DataSource.Length, SecondLength];
        //Copy values over
    	for (int i = 0; i < DataSource.Length; i++)
    	{
    		Target[i, 0] = DataSource[i];
    	}
    	
    	return Target;
    }
