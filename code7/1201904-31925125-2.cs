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
        var versionRegexp = new Regex("^" + firstPart + "\\.([\\d]+\\.){1}([\\d]+\\.){1}([\\d]+\\.){1}([\\d]+\\.)?[\\w\\d]+$");
        foreach (var name in names)
        {
            if (versionRegexp.IsMatch(name))
            {
                Console.WriteLine(name);
                foreach (Group group in versionRegexp.Match(name).Groups)
                {
                    Console.WriteLine("Index {0}: {1}", group.Index, group.Value);
                }
            }
        }
        Console.ReadKey();
