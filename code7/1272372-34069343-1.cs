    static void ProcessFile(string inputfile, string outputfile)
    {
        // Read the files by lines.
        string[] lines = File.ReadAllLines(inputfile);
        // We'll process in reverse, so create a stack (LIFO) for the results.
        Stack<string> results = new Stack<string>();
        // Process each line, checking that if it doesn't match the format, then we append to previous line.
        string resultLine = "";
        for (int i = lines.Length - 1; i >= 0; --i)
        {
            resultLine = lines[i] + resultLine;
            int lineParts = resultLine.Split('|').Count();
            if (lineParts == 4) // Well-formatted line.
            {
                results.Push(resultLine);
                resultLine = "";
            }
            else if (lineParts < 4) // An invalid linefeed from the previous entry.
            {
                // We prepend a space to replace the linebreak; then just continue through loop, where the current line will be appended to previous.
                resultLine = " " + resultLine;
            }
            else // lineParts > 4... unexpected
            {
                throw new InvalidOperationException("What to do here?");
            }
        }
        // Now that all our lines have been fixed, write them back out.
        File.WriteAllLines(outputfile, results.ToArray());
    }
