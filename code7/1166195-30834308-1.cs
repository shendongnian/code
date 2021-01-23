    try
    {
        List<StreamReader> lijst = new List<StreamReader>();
        StreamReader qwe = new StreamReader("C:\\123.txt");
        StreamReader qwer = new StreamReader("C:\\1234.txt");
        lijst.Add(qwe);
        lijst.Add(qwer);
    
        // Use the stream readers
    }
    // you can use or not use catch here, it depends
    finally
    {
        qwe.Dispose();
        qwer.Dispose();
    }
