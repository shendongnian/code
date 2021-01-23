      static void Main(string[] args)
      {
         HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
         HashSet<int> set2 = new HashSet<int> { 2, 1, 3 };
         HashSet<int> set3 = new HashSet<int> { 1, 2, 3 };
         Console.WriteLine(set1.SetEquals(set2));          // True
         Console.WriteLine(set1.SequenceEqual<int>(set2)); // False
         Console.WriteLine(set1.SequenceEqual<int>(set3)); // True
      }
