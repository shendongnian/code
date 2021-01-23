    string[,] names = new string[7, 2] { { "Cheryl Cole", "F" }, { "Hilary Clinton", "F" }, { "Noel Gallagher", "M" }, { "David Cameron", "M" }, { "Madonna", "F" }, { "Sergio Aguero", "M" }, { "Sheik Mansour", "M" } };
    int mCount = 0;
    int fCount = 0;
    
    int length = names.GetLength(0);
    
    for (int i = 0; i < length; i++)
    {
    	if (names[i, 1] == "M")
    	{
    		mCount += 1;
    	}
    	else if (names[i, 1] == "F")
    	{
    		fCount += 1;
    	}
    }
    
    Console.WriteLine("mCount = {0}", mCount);
    Console.WriteLine("fCount = {0}", fCount);
    Console.Read();
