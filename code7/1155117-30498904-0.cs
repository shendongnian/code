    public static class MySettings
    {
      //some lines
      public static ArrayList MyObjects { get; private set; }
    
      static MySettings()
      {
        //some lines
        MyObjects = new ArrayList();
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
