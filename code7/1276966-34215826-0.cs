    public static class MyRecordExtensions
    {
      public static string GetMyField(this ParseObject parseObject)
      {
         return GetProperty<string>( "MyField" );
      }
    
      // Not sure if you need the setters at all, but just in case
      public static void SetMyField(this ParseObject parseObject, string newValue)
      {
         SetProperty<string>( newValue, "MyField" );
      }
    
    }
