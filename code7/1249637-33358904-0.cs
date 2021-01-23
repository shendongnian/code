    private bool HasMoreThanNumberOfLines(Stream stream, Encoding enc, int number_of_lines)
    {
        long current_position = stream.Position;
        stream.Position = 0;
        try
        {
            using(StreamReader sr = new StreamReader(stream, enc, true, 1024, true))
            { 
                for (int i = 0; i < number_of_lines + 1 ; i++)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                        return false;
                }
            }
            return true;
        }
        finally
        {
            stream.Position = current_position;
        }
    }
