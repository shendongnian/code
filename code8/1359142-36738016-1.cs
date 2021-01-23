      String replaceMe = new String('a', 10000000) + 
                         new String('b', 10000000) + 
                         new String('a', 10000000);
      Stopwatch sw = new Stopwatch();
      sw.Start();
      // String replacement 
      if (replaceMe.Contains("a")) {
        replaceMe = replaceMe.Replace("a", "b");
      }
      // Char replacement
      //if (replaceMe.Contains('a')) {
      //  replaceMe = replaceMe.Replace('a', 'b');
      //}
      sw.Stop();
      Console.Write(sw.ElapsedMilliseconds);
