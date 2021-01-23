    static class Global
    {
       private static string _globalVar = "";
 
       public static string Filename
       {
           get { return _globalVar; }
           set { _globalVar = value; }
       }
       private static string _globalVar2 = "";
       public static string Filename2
       {
           get { return _globalVar2; }
           set { _globalVar2 = value; }
       }
    }
