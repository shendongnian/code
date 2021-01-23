    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp2
    {
        class Program
        {
            static void Main(string[] args)
            {
                HashSet<HashSet<int>> intArrList = new HashSet<HashSet<int>>(new HashSetIntComparer());
                intArrList.Add(new HashSet<int>(3) { 0, 0, 0 });
                intArrList.Add(new HashSet<int>(5) { 20, 30, 10, 4, 6 });  //this
                intArrList.Add(new HashSet<int>(3) { 1, 2, 5 });
                intArrList.Add(new HashSet<int>(5) { 20, 30, 10, 4, 6 });  //this
                intArrList.Add(new HashSet<int>(3) { 12, 22, 54 });
                intArrList.Add(new HashSet<int>(5) { 1, 2, 6, 7, 8 });
                intArrList.Add(new HashSet<int>(4) { 0, 0, 0, 0 });
    
                // Checking the output
                foreach (var item in intArrList)
                {
                    foreach (var subHasSet in item)
                    {
                        Console.Write("{0} ", subHasSet);
                    }
    
                    Console.WriteLine();
                }            
    
                Console.Read();
            }
    
            private class HashSetIntComparer : IEqualityComparer<HashSet<int>>
            {
                public bool Equals(HashSet<int> x, HashSet<int> y)
                {
                    // SetEquals does't set anything. It's a method for compare the contents of the HashSet. 
                    // Such a poor name from .Net
                    return x.SetEquals(y);
                }
    
                public int GetHashCode(HashSet<int> obj)
                {
                    //TODO: implemente a better HashCode
                    return base.GetHashCode();
                }
            }
        }
    }
    Output:
    0
    20 30 10 4 6
    1 2 5
    12 22 54
    1 2 6 7 8
