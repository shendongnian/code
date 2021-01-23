    string filename = "test.txt";
    File.WriteAllText(filename, "{One\nTwo\nThree}"); // Note curly brace at the end.
    using (var file = new StreamWriter(File.OpenWrite(filename)))
    {
        file.BaseStream.Position = file.BaseStream.Length - 1;
        file.Write("\nfour}"); // New line at end, previous brace is replaced.
    }
