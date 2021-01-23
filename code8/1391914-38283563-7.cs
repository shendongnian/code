    void Split(string file)
    {
        using (var sr = new StreamReader(file, Encoding.UTF8))
        {
            var line = sr.ReadLine();
            while (!String.IsNullOrEmpty(line))
            {
                // whatever you do, make sure this file your writed
                // is ordered, just writing a single line is the easiest
                using (var sw = new StreamWriter(CreateUniqueFilename()))
                {
                    sw.WriteLine(line);
                }
                line = sr.ReadLine();
            }
        }
    }
