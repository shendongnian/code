    public class Symbol
    {
       public string Code;
       public string Name;
        
       public Dictionary<string, DataLine> DataLines = new Dictionary<string, DataLine> { {"day", new DataLine()}, {"week", new DataLine()} , {"month", new DataLine()}};
    }
