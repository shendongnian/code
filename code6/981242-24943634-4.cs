    List<ProcessInfo> processes = new List<ProcessInfo>();
    using(StreamReader reader = new StreamReader("input.txt'))
    {
      reader.ReadLine(); //The headers don't matter!
    
      string currentLine;
      while (currentLine = reader.ReadLine() != null)
      {
          ProcessInfo newInfo = new ProcessInfo();
          //Actual parsing left up to the reader; String.Split is your friend.
          processes.Add(newInfo);
      }
    }
