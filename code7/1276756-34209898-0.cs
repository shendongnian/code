    public static class Storage
    {
         public static void SessionAdd<T>(string label, T value)
         {
              if(!string.IsNullOrEmpty(label))
                   HttpContext.Current.Session.Add(label, value);
         }
    
         public static void SessionModify<T>(string label, T value)
         {
              if(HttpContext.Current.Session[label] != null)
              {
                   HttpContext.Current.Session[label] = value;
                   return;
              }
           
              SessionAdd(label, value);              
         }
         public static T SessionModifyAndReturn<T>(string label, T value) where T : class, new()
         {
              var content = new  T();
              if(HttpContext.Current.Session[label] != null)
                   HttpContext.Current.Session[label] = value;
              else { SessionAdd(label, value); }
             
              content = value;
              return content;
         }           
    }
