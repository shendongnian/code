          Try with this it will work  
      namespace LINQExperiment1
      {
      class Program
      {
      static void Main(string[] args)
      {
       string[] sentence = new string[] { "apple", "orange", "baboons  cows", " rainbow", "unicorns  gummy bears" };
      Console.WriteLine("option 1:"); Console.WriteLine("————-");
      // option 1: Select returns three string[]’s with
      // three strings in each.
      IEnumerable<string[]> words1 =
      sentence.Select(w => w.Split(' '));
      // to get each word, we have to use two foreach loops
      foreach (string[] segment in words1)
      foreach (string word in segment)
      Console.WriteLine(word);
      Console.WriteLine();
      Console.WriteLine("option 2:"); Console.WriteLine("————-");
      // option 2: SelectMany returns nine strings
      // (sub-iterates the Select result)
      IEnumerable<string> words2 =
      sentence.SelectMany(segment => segment.Split(','));
      // with SelectMany we have every string individually
      foreach (var word in words2)
      Console.WriteLine(word);
      // option 3: identical to Opt 2 above written using
      // the Query Expression syntax (multiple froms)
      IEnumerable<string> words3 =from segment in sentence
      from word in segment.Split(' ')
      select word;
       }
      }
     }
