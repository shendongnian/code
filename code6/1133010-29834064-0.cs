    public static List<string> GetLines(string filename)
    {
        List<string> result = new List<string>(); // A list of strings 
        // Create a stream reader object to read a text file.
        using (StreamReader reader = new StreamReader(filename))
        {
            string line = string.Empty; // Contains a single line returned by the stream reader object.
            // While there are lines in the file, read a line into the line variable.
            while ((line = reader.ReadLine()) != null)
            {
                // If the line is not empty, add it to the list.
                if (line != string.Empty)
                {
                    result.Add(line);
                }
            }
        }
        return result;
    }
