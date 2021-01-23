    // replace input and output filenames as you wish
    var inputFilename = @"m:\EmailParser\file.txt";
    var outputFilename = @"m:\EmailParser\output.csv";
    // StreamReader and StreamWriter are used together, so that no intermediate structure is necessary
    using (StreamReader sr = new StreamReader(inputFilename, Encoding.UTF8, true, 512))
    {
        using (StreamWriter sw = File.AppendText(outputFilename))
        {
            bool first = true;
            string currentLine;
            while ((currentLine = sr.ReadLine()) != null)
            {
                // empty lines, with no relevant data whatsoever
                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    // if not the check for "first", multiple empty lines would produce empty CSV lines
                    if (!first) sw.WriteLine();
                    first = true;
                }
                //lines containing the useful information
                else
                {
                    // if not the check for "first", the comma would be needlessly added at the end
                    sw.Write((first ? "" : ",") + currentLine.Trim());
                    first = false;
                }
            }
        }
    }
