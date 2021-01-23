    while (_isRunning)
    {
       if (_isRunning && _queueCommands .Count != 0)
       {
           if (_queueCommands.TryDequeue(out command))
           {
               // do the job, this is FIFO
           }
       }
       // you wanna wait here, but only if there's nothing new to do
       if (_isRunning && _queueCommands.Count == 0)
       {
           _trigger.WaitOne(10000, false);
       }
    }
