    static void Main(string[] args)
    {
        try
        {
            var validCode   = "alert('Hello World!');";
            var invalidCode = "alert['Hello World!');";
            var jsParser = new JavaScriptParser();
            var result = jsParser.Parse(validCode);
            result = jsParser.Parse(invalidCode); //Will throw...
        }
        catch (Exception ex)
        {
            //Invalid input!!
        }
    }
