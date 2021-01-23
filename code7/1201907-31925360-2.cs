    List<string> names = new List<string> { "A.B.C.1.2.3.4.zip",
                                            "A.B.C.1.2.3.5.zip",
                                            "A.B.C.3.4.5.dll",
                                            "A.B.C.1.2.3.6.zip" ,
                                            "A.B.C.1.2.3.dll",
                                            "X.Y.Z.7.8.9.0.zip",
                                            "X.Y.Z.7.8.9.1.zip" };
    var groupedFileNames = names.GroupBy(file => new string(Path.GetFileNameWithoutExtension(file)
                                                             .Reverse()
                                                             .SkipWhile(c => Char.IsDigit(c) || c == '.')
                                                             .Reverse().ToArray()));
    foreach (var g in groupedFileNames)
    {
        Console.WriteLine(g.Key);
        foreach (var file in g)
            Console.WriteLine("    " + file);
    }
