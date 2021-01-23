    using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Delete | FileShare.Read | FileShare.Write))
    using (var streamReader = new StreamReader(fileStream))
    {
        string line;
        bool running = true; // we may want to terminate this loop in some condition.
        while (running)
        {
            line = streamReader.ReadLine();
            if (line != null)
            {
                Console.WriteLine(line);
            }
            else
            {
                while (streamReader.EndOfStream)
                {
                    Thread.Sleep(1000); // wait around for n time. This could end up in an infinte loop if the file is not written to anymore. 
                }
            }
       }
       // FIXME: The stream reader stops, instead of doing a continous read.
       Console.WriteLine("End of file");
    }
