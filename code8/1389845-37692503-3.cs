    void Main()
    {
    	Object kj = 12;
    	
    	GetData(ref kj); 
    	Console.WriteLine(kj); //Prints 15
    }
    
    void GetData(ref Object o)
    {
    	o = 15;
    }
