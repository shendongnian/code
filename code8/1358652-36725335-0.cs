    public void Process(List<string> msg)
    {
        bool permfail = false;
        bool complete = false;
        int runCount = 0;
        while (!complete && !permfail)
        {
            try
            {
                AttemptProcess(msg);
                complete = true;
    
            }
            catch
            {
                if (runCount++ > 10)
                    permfail = true;
                else
                    System.Threading.Thread.Sleep(new TimeSpan(0, 2, 0));
            }
        }
    }
    void AttemptProcess(List<string> msg)
    {
        // Do whatever processing here
    }   
