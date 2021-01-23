    Thread connectThread = new Thread(new ThreadStart(CheckWhenToCloseMyForm)); 
    public void CheckWhenToCloseMyForm()
    {
        while (true)
        {
            CallSomeFunc();
            CallSomeFunc1();
            if (allconditionsmet)
            {
                System.Threading.Thread.Sleep(1000);
                CloseMyForm()
            }        
        }       
    }
