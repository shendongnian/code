    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Sftp,
        HostName = "localhost",
        PortNumber = 2222,
        UserName = "test",
        SshHostKeyFingerprint = "ssh-dss 1024 0b:77:8b:68:f4:45:b1:3c:87:ad:5c:be:3b:c5:72:78",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        List<string> prevFiles = null;
        while (true)
        {
            // collect file list
            List<string> files =
                session.EnumerateRemoteFiles("/B/watchchanges/tree", "*.*", EnumerationOptions.AllDirectories)
                    .Select(fileInfo => fileInfo.FullName)
                    .ToList();
            if (prevFiles == null)
            {
                // in the first round, just print number of files found
                Console.WriteLine("Found {0} files", files.Count);
            }
            else
            {
                // then look for differences against the previous list
                IEnumerable<string> added = files.Except(prevFiles);
                if (added.Any())
                {
                    Console.WriteLine("Added files:");
                    foreach (string path in added)
                    {
                        Console.WriteLine(path);
                    }
                }
                IEnumerable<string> removed = prevFiles.Except(files);
                if (removed.Any())
                {
                    Console.WriteLine("Removed files:");
                    foreach (string path in removed)
                    {
                        Console.WriteLine(path);
                    }
                }
            }
            prevFiles = files;
            Console.WriteLine("Sleeping 10s...");
            Thread.Sleep(10000);
        }
    }
