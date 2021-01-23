    void Main()
    {
    	Object kj = 12;
    	
    	GetData(kj); 
    	Console.WriteLine(kj); //Prints 12
    }
    
    void GetData(Object o)
    {
    	//At this point, o is a pointer to the object 'kj'
    	o = 15;
    	
    	//Now o is a pointer to a _new_ object which boxes the value 15.
    }
