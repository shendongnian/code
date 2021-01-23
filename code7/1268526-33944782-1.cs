    public class Test
    {
      public override sealed string ToString()
      {
        return "a";
      }
    }
    public class Test1 : Test
    {
      public override string ToString()
      {
        return "";
      }
    }
