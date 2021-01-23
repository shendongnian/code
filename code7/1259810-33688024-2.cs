    for (var i = 1; i < 100000; ++i)
    {
        try
        {
            Console.WriteLine(System.Text.Encoding.GetEncoding(i).GetString(bytes));
            Console.WriteLine("Encoding: {0}", i);
            Console.WriteLine(System.Text.Encoding.GetEncoding(i).EncodingName);
            Console.WriteLine();
        }
        catch
        {
        }
    }
