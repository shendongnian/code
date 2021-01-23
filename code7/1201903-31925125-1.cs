        var firstPart = Console.ReadLine();
        var names = new List<string>
        {
            "A.B.C.1.2.3.4.zip",
            "A.B.C.1.2.3.5.zip",
            "A.B.C.1.2.3.6.zip",
            "A.B.C.1.2.3.dll",
            "X.Y.Z.7.8.9.0.zip",
            "X.Y.Z.7.8.9.1.zip"
        };
        var versionRegexp = new Regex("^" + firstPart + ".([\\d]+\\.){3,4}[\\w\\d]");
        foreach (var name in names)
        {
            if (versionRegexp.IsMatch(name))
            {
                Console.WriteLine(name);
                var matches = versionRegexp.Matches(name);
            }
        }
        Console.ReadKey();
