    public static class MySettings
    {
      //some lines
      public List<MyObject> myObjects { get; set; }
    
      static MySettings()
      {
        //some lines
        myObjects = new List<MyObject>();
      }
    }
    
    public class MyObject
    {
      public int a { get; set; }
      public int b { get; set; }
    
      public MyObject()
      {
        a = 1;
        b = 2;
      }
    }
