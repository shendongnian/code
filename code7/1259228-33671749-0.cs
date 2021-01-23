    void Main()
    {
      string inFileName = @"C:\Users\Public\TestFolder\WriteLines2.txt";
      string outFileName = @"C:\Users\Public\TestFolder\WriteLines2_Out.txt";
      
      using(var r = File.OpenText(inFileName))
      using(var w = File.CreateText(outFileName))
      {
        string line;
        while ( (line = r.ReadLine()) != null)
        {
            w.WriteLine(string.Format(@"'{0}',",line));
        }
      }
    }
