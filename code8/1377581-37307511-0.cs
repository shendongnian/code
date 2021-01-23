    using System.IO;
    using System;
    class Program
    {
        static void Main()
       {
         int[] datarow = {1,2,3,4,5};
         int i=0;
         do{
               Console.Write(datarow[i]+",");
               i++;
           }while(i<datarow.Length-1);
         Console.Write(datarow[i]+"\n");
      }
    }
