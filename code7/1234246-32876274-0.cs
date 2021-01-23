    static void Bar()
    {
        int int1 = 50000;
        double double1 = 5800.0;
        string test = "Test\r\nSome\r\nMultiline\r\nstuff.";
        StringBuilder sb = new StringBuilder();
        StringWriter writer = new StringWriter(sb);
        IndentedTextWriter itw = new IndentedTextWriter(writer, new string(' ', 18));
        itw.Write("{0,8};{1,8};", int1, double1);
        itw.Indent++;
        test.Split(new char[] { '\n' }).All(s => { itw.WriteLine(s); return true; });
        Console.Write(sb.ToString());
    }
