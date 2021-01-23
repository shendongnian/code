        // Example #1: Write an array of strings to a file.
        // Create a string array that consists of three lines.
        string[] lines = { "First line", "Second line", "Third line" };
        // WriteAllLines creates a file, writes a collection of strings to the file,
        // and then closes the file.  You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllLines(string.Format(@"C:\Users\Public\TestFolder\WriteLines{0}.txt",DateTime.Now.ToString("yy,mm,dd")), lines);
