    string oldS;
    int count;
    void Method(string s)
    {
        if (ReferenceEquals(oldS, s)) // compare by reference
        {
            count++;
        }
        oldS = s;
    }
    public void Test()
    {
        for (var i = 0; i < 100; i++)
        {
            Method("string");
        }
        Console.WriteLine(count);
    }
