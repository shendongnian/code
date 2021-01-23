    void Main()
    {
      using (var stream = File.OpenText(@"d:\temp\SampleTextFile.txt"))
      {
        while (stream.ReadLine() != "[Data]") { };
        stream.ReadLine();
    
        
        while (!stream.EndOfStream)
        {
          string line = stream.ReadLine();
          // parse the line and do whatever. ie:
          // line.Split(' ').Where(l => !string.IsNullOrEmpty(l));
        }
      }
    }
