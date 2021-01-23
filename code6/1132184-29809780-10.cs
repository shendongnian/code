    class Program
    {
        static void Main(string[] args)
        {
            // Get all lines that start with a given word from a file
            var result = GetLinesWithWord("The", "temp.txt");
    
            // Display the results.
            foreach (var line in result)
            {
                Console.WriteLine(line + "\r");
            }
    
            Console.ReadLine();
        }
    
        public static List<string> GetLinesWithWord(string word, string filename)
        {
            List<string> result = new List<string>(); // A list of strings where the first word of each is the provided search term.
    
            // Create a stream reader object to read a text file.
            using (StreamReader reader = new StreamReader(filename))
            {
                string line = string.Empty; // Contains a single line returned by the stream reader object.
    
                // While there are lines in the file, read a line into the line variable.
                while ((line = reader.ReadLine()) != null)
                {
                    // If the line is white space, then there are no words to compare against, so move to next line.
                    if (line != string.Empty)
                    {
                        // Split the line into parts by a white space delimiter.
                        var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
                        // Get only the first word element of the line, trim off any additional white space
                        // and convert the it to lowercase. Compare the word element to the search term provided.
                        // If they are the same, add the line to the results list.
                        if (parts.Length > 0)
                        {
                            if (parts[0].ToLower().Trim() == word.ToLower().Trim())
                            {
                                result.Add(line);
                            }
                        }
                    }
                }
            }
    
            return result;
        }
    }
    
