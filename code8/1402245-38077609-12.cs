    public void ByValueCall(string s)
    {
        s = "Goodbye";
    }
    public void ByReferenceCall(ref string s)
    {
        s = "Goodbye";
    }
    var myString = "Hello!";
    Console.WriteLine(ByValueCall(myString )); //outputs "Hello!"
    Console.WriteLine(ByValueCall(myString )); //outputs "Goodbye!"
