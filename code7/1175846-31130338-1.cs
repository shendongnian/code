    void Main()
    {
        //I am defining the implementation of a method which requires as integer as a parameter, but I don't actually invoke it, just define it.
    	ExecuteMethod(i => Console.WriteLine(i));
    }
    
    public static void ExecuteMethod(Action<int> method)
    {
        //I don't know what method does, all I know is that I am running it with the number 5.
       	method(5);
    }
