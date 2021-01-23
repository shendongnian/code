    public class textToEnabledConverter:IValueConverter
    {
       ...convert(...)
       {
         if(String.IsnullOrEmpty(value))
        {
          return false;
        }
         return true;
      }
       ...convertBack(...)
      {
        //do not modify
      }
    }
