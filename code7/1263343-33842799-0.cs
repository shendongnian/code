    System.Collections.Concurrent.ConcurrentQueue<string> queue = new System.Collections.Concurrent.ConcurrentQueue<string>();
    bool readFinished = false;  
    Task tRead = Task.Run(async () => 
    {
        using (FileStream fs = new FileStream())
        {
            using (StreamReader re = new StreamReader(fs))
            {
                string line = "";
                while (!re.EndOfStream)
                    queue.Enqueue(await re.ReadLineAsync());
            }
        }
    });
    
    Task tLogic = Task.Run(async () =>
    {
        string data ="";
        while (!readFinished)
        {
            if (queue.TryDequeue(out data))
                //Process data
            else
                await Task.Delay(100);
        }
    });
    
    tRead.Wait();
    readFinished = true;
    tLogic.Wait();
