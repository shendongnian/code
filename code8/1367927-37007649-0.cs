    static task<int> async Bla2Async(object o)
    {
        return await WebClient.PostToWebAPIAsync(o);//Log time to complete. returns response code(int) from http response
    }
    static void Bla(object o)
    {
        var response = Bla2Async(o);
    }
    static void Main(string[] args)
    {
        Bla(new object());
        
        ...
    }
