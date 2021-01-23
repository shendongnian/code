    void SomeHigherFunction()
    {
        try
        {
            int x = GetSomeDataFromFileA();  // throws InvalidDataException
            int y = GetSomeDataFromFileB();  // throws InvalidDataException
        }
        catch(InvalidDataException ex)   // what failed ? 
        {
            Console.WriteLine(ex.Message);
            //will show to you what failed
        }
    }
    public int GetSomeDataFromFileA()
    {
        //do stuff
        if(error)
            throw new InvalidDataException ("'A' failed");
    }
    
    public int GetSomeDataFromFileB()
    {
        //do stuff
        if(error)
            throw new InvalidDataException ("'B' failed");
    }
