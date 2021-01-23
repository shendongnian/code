    private void test<T>(T obj){
        // Do common stuff
    
    }
    public void overloaded(Object1 obj){
        test(obj);
        Console.WriteLine("Do Object 1 stuff");   
    }
    public void overloaded(Object2 obj){
        test(obj);
        Console.WriteLine("Do Object 2 stuff");   
    }
