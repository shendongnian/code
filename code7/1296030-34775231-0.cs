    private Process myProcess = new Process();
    private int elapsedTime;
    private bool eventHandled;
    // Print a file with any known extension.
    public void PrintDoc(string fileName)
    {
        elapsedTime = 0;
        eventHandled = false;
        try
        {
            // Start a process to print a file and raise an event when done.
            myProcess.StartInfo.FileName = fileName;
            myProcess.StartInfo.Verb = "Print";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.EnableRaisingEvents = true;
            myProcess.Exited += new EventHandler(myProcess_Exited);
            myProcess.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred trying to print \"{0}\":" + "\n" + ex.Message, fileName);
            return;
        }
        // Wait for Exited event, but not more than 30 seconds.
        const int SLEEP_AMOUNT = 100;
        while (!eventHandled)
        {
            elapsedTime += SLEEP_AMOUNT;
            if (elapsedTime > 30000)
            {
                break;
            }
            Thread.Sleep(SLEEP_AMOUNT);
        }
    }
