    object res;
    // code where I set res = something;
    using (var reader = new System.IO.StringReader("test"))
    {
        res = reader.ReadToEnd();
    }
    res
