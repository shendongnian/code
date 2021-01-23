    public class TestPrivateConstructor
    {
    private TestPrivateConstructor()
    {
      Console.WriteLine("Instance is created, Private Constructor called");
    }
    
    static TestPrivateConstructor _instance;
    
    public static TestPrivateConstructor GetInstance()
    {
        if(_instance == null)
        {
           _instance = new TestPrivateConstructor();
        }
        return _instance;
    }
    
    public static void DisposeInstance()
    {
       if(_instance !=null)
       {
          _instance.Dispose();
          _instance = null;
       }
    }
    public void TestMethod()
    {
      Console.WriteLine("Test MEthod Called");
    }
    void Dispose()
    {
     //Do something
    }
    }
