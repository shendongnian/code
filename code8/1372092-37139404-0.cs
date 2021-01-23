    using System;
    
    public class Example
    {
       public static void Main()
       {
          String s = "AaBbCcDd";
          var chars = s.ToCharArray();
          Console.WriteLine("Original string: {0}", s);
          Console.WriteLine("Character array:");
          for (int ctr = 0; ctr < chars.Length; ctr++)
             Console.WriteLine("   {0}: {1}", ctr, chars[ctr]);
       }
    }
    
    
