    public static class SomeNameHelper
    {
       public static object IDToUrl(int myNumber)
       {
          return Encrypt(myNumber.ToString());
       }
       public static object Encrypt(string s){
          ... whatever code that is required...
       }
    }
