    public DBEngine<int, DBElement<int, string>> foo =
        new DBEngine<int, DBElement<int, string>>();
    public static void Main(string[] args)
    {
        var te = new TEST_ENGINE();
        TE.foo.insert();
