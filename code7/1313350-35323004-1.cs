    using (StreamReader sr = new StreamReader(@"filepath\document.txt"))
    {    
        // read the first line
        string line = sr.ReadLine();
        // parse the line for an integer
        int value;
        int.TryParse(line, out value);
        // if the line in the file was indeed an integer, the variable value will be equal to it now
        // sr will be disposed at end of using block
    }
