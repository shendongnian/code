    string write = "some Chinese characters here";
    using(var writer = new StreamWriter("blablabla", false, Encoding.Unicode)
        writer.Write(write);
    using(var reader = new StreamReader("blablabla", Encoding.Unicode)
    {
        var read = reader.ReadToEnd();
        if(read != write)
            throw new Exception("omg");
    }
