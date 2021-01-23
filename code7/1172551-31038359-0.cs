    List<string> a = ...
    List<int> b =    ...
    List<int> key =  ...
    static void funciton1(int _i)  // Gets called MANY MANY times a second!
    {
        for (int i = 0; i < b.Count; i++)
        {
            if (b[i] > _i) // hot
            {
                if (a[i] == "hello") // cold
                {
                    doSomething(key[i]); // cold
                    // or maybe
                    doSomething(i);
                }
            }
        }
    }
