    AsyncLocal<string> Data = new AsyncLocal<string>();
    ThreadLocal<string> Data1 = new ThreadLocal<string>();
    Data.Value = "One";
    Data1.Value = "Two";
    
    Task.Factory.StartNew(() =>
    {
      string InnerValue = Data.Value; //InnerValue equals to "One", 
      string InnerValue1 = Data1.Value; //InnerValue1 equals to null, 
    });
