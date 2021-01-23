        string path ="<Path of file>"
        List<string> lines = System.IO.File.ReadAllLines(path).ToList<string>();
        //give the line to be inserted
        lines[10]="New String";
        System.IO.File.WriteAllLines(path, lines);
