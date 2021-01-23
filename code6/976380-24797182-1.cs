    private AutoResetEvent signal = new AutoResetEvent(false);
    void MethodB()
    {
       //process data
       if(condition)
       {
           signal.Set();//Say you're finished
       }
    }
    
    void MethodA()
    {
        //Do something
    
        signal.WaitOne();//Wait for the signal
        //Here do whatever you want. We received signal from MethodB
    }
