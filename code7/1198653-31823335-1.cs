    string text = System.IO.File.ReadAllText(@"C:\test.cpp");
    string[] lines = text.Split(new string[] { System.Environment.NewLine },
        StringSplitOptions.None);
    //Gain control with each lines process as you wish, use StringBuilder etc.
    for (int i = 0; i < lines.Length; i++ )
    {
        Console.WriteLine(lines[i]);
    }
    Console.ReadLine();
