    using System;
    using System.Collections.Generic;
    namespace AvoidBoxing
    {
      static class Program
      {
        static void Main()
        {
          var myStruct = new List<int> { 10, 20, 30, }.GetEnumerator();
          myStruct.MoveNext(); // moves to '10' in list
          //
          // UNCOMMENT ONLY *ONE* OF THESE CALLS:
          //
          //UseMyStruct(ref myStruct);
          //UseMyStructAndBox(ref myStruct);
          Console.WriteLine("After call, current is now: " + myStruct.Current);
        }
        static void UseMyStruct<T>(ref T myStruct) where T : IEnumerator<int>
        {
          myStruct.MoveNext();
        }
        static void UseMyStructAndBox<T>(ref T myStruct)
        {
          ((IEnumerator<int>)myStruct).MoveNext();
        }
      }
    }
