    namespace MyApp.MyExtensions
    {
       public static class CloneExtensions 
       {
           public static T CloneJson<T>(this T source)
           {
               if (Object.ReferenceEquals(source, null))
                   return default(T);
       
               return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
           }
       }
    }
