    using System.IO;
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            var stores = new List<string>{"aaa","bbb","ccc"};
            var searchValue = "xxx,aaa"; // should find store "aaa"
            
            foreach(var store in stores){
                if(searchValue.Contains(store)){
                    Console.WriteLine(string.Format("found - {0}",store));
                }
            }
        }
    }
