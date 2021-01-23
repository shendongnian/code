    public class UniversalConvertor {
         public static string Convert (object o) {
           return ... some convert logic ... :)
         }
    } 
  
    ...
    MethodInfo minfo = typeof (UniversalConvertor).GetMethod ("Convert", BindingFlags.Static | BindingFlags.Public);
