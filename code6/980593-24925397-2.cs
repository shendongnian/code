    long pos = 0;
    private void ProcessFile( string filePath)
    {
        using (var sr = new StreamReader(filePath))
        {
            string line;
              
            long count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                count += 1;
                if (pos < count)
                {
                    Console.Write("{0:d3} ", pos);
                    Console.WriteLine(line);
                    pos += 1;
                }
            }
        }
    }
