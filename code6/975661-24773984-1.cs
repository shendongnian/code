    public static class MyExtension{ 
       public static bool isPalindrome(this string val){
            return val== new string(val.Reverse().ToArray());
       }
    } 
