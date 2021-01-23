    public void Insert<T>(T input)
    {
        // DB setup code goes here
        var parameter = new SqlParameter("@input", input);
        // Finish DB code here
    }
    // Call it like this
    myClass.Insert<int>(inputData);
