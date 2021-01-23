    public static List<Tuple<string, string>> GetAllData()
    {
      List<Tuple<string, string>> Result = new List<Tuple<string, string>>();
      using (var sr = new StreamReader(@"Country.txt"))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            int index = line.LastIndexOf(" ");
            var Name = line.Substring(0, index);
            var Code = line.Substring(index + 1);
            Result.Add(new Tuple<string, string>(Name, Code));
        }
      }
    
      return Result;
    }
