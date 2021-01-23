    static void SolutionTwo(ConnectionInfo connection)
    {
        using (SshClient client = new SshClient(connection))
        {
            client.ErrorOccurred += (e, s) =>
            {
                Debug.WriteLine(s.Exception);
            };
    
            client.Connect();
    
            using (var stream = client.CreateShellStream("dumb", 512, 96, 800, 600, 8191))
            {
                stream.ErrorOccurred += (e, s) =>
                {
                    Debug.WriteLine(s.Exception);
                };
                // read welcome message
                Console.WriteLine(ReadFromStream(stream));
    
                // first command and read its output
                WriteToStream(stream, "uname\n");
                Console.WriteLine(ReadFromStream(stream));
    
                // second and output
                WriteToStream(stream, "df\n");
                Console.WriteLine(ReadFromStream(stream));
    
                // third and output
                WriteToStream(stream, "ps aux\n");
                Console.WriteLine(ReadFromStream(stream));
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" >>>>>we are all done");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    
    
    
    static void WriteToStream(ShellStream stream, string command) 
    {
        stream.Write(command);
    }
    
    static StringBuilder ReadFromStream(ShellStream stream)
    {
        var result = new StringBuilder();
        // there seems to be a timing/concurrency issue
        // which I only could fix with using this 
        // useless Sleep calls
        Thread.Sleep(500);
        // wait for the Stream to have data
        while (stream.Length == 0)
        {
            // yes, I know ...
            Thread.Sleep(500);
        }
        // let's read!
        string line;
        while ((line = stream.ReadLine()) != null)
        {
            result.AppendLine(line);
        }
        return result;
    }
