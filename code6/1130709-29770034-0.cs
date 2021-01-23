    using System.IO;
    using System;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            // declare and initialize a JAGGED array
             int[][] a=new int[][]{   new int[] { 8, 63  },
                                new int[]  { 4, 2   }, 
                                new int[]  { 0, -55 }, 
                                 new int[] { 8, 53  }, 
                                 new int[] { 2, -120}, 
                                 new int[] { 8, 57  }  };
          
          //using LAMBDA expression
          Array.Sort(a, (a1, a2) => { return (a2[0]-a1[0])+((a2[0]-a1[0])==0?(a2[1]-a1[1]):0); 
          });
            
           Console.WriteLine("LAMBDA Sorting");   
          for(int i=0;i<6;i++)
             Console.WriteLine(" {0}:{1} ",a[i][0],a[i][1]);
         
          //using LINQ   
          var sorted = from x in a
                 orderby x[0] descending ,x[1]  descending
                 select x;
           
           Console.WriteLine("LINQ Sorting");      
           foreach(var item in sorted )
            Console.WriteLine(" {0}:{1} ",item[0], item[1]);
        }
