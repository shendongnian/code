     public static void Main()
     {
         unsafe
         {
             var s = "Naveen";
             fixed (char* cp = s)
             {
                 for (int i = 0; cp[i] != '\0'; i++)
                 {
                     Console.Write(cp[i]);
                 }
             }
         }
     }
