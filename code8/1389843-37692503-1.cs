    void Main()
    {
    	Object kj = 12;
    	
    	GetData(ref kj); 
    	Console.WriteLine(kj);
    }
    
    void GetData(ref Object o)
    {
    	o = 15;
    }
