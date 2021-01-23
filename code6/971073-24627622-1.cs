    const string file = "test.log";
    AutoResetEvent signal = new AutoResetEvent(false);
    
    // Writes lines to the log file.
    var t1 = Task.Factory.StartNew(() =>
    {
        using (var fileStream = File.Open(file, FileMode.Create, FileAccess.Write, FileShare.Read))
        {
            using (var streamWriter = new StreamWriter(fileStream))
            {
                for (var i = 0; i < 10; i++)
                {
                    streamWriter.WriteLine(i);
                    streamWriter.Flush();
                    signal.Set();
                    Thread.Sleep(10);
                }
            }
        }
    
        File.Delete(file);
        signal.Set();
    });
    
    // Reads lines from the log file.
    var t2 = Task.Factory.StartNew(() =>
    {
        signal.WaitOne();
        using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Delete | FileShare.Read | FileShare.Write))
        {
            using (var streamReader = new StreamReader(fileStream))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    signal.WaitOne();
                    Console.WriteLine(line);
                }
    
                // FIXME: The stream reader stops, instead of doing a continous read.
                Console.WriteLine("End of file");
            }
        }
    });
    
    Task.WaitAll(t1, t2);
