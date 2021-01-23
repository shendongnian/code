    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication19
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<List<int>> multiarray = new List<List<int>>{    
                    new List<int> { 8, 63  },
                    new List<int>  { 4, 2   }, 
                    new List<int>  { 0, -55 }, 
                    new List<int>  { 8, 57  }, 
                    new List<int>  { 2, -120}, 
                    new List<int>  { 8, 53  }  
                };
               
                List<List<int>> sortedList = multiarray.OrderBy(x => x[1]).OrderBy(y => y[0]).ToList();
            }
        }
    }
