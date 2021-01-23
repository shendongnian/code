    private DateTime LastCalled;
    public void MyFunc()
    { 
        
        if(LastCalled == null)// Will only happen once, first time the method is called
        {
              LastCalled = DateTime.Now; 
        }
        else if (LastCalled > DateTime.Now.AddSeconds(-3)
        {
             return; // or do whatever else you want, throw an exception etc
        };
        LastCalled = DateTime.Now;
        // Your actual method code here
    }
    
