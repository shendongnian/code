        string path ="<Path of file>"
        List<string> lines = System.IO.File.ReadAllLines(path).ToList<string>();
        //give the line to be inserted
        lines.Insert(5, "some string");
        ines.Insert(8, "other string");
        System.IO.File.WriteAllLines(path, lines);
