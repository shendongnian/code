    public interface IWriter
    {
       void WriteData(data);
       string Name {get;}
    }
    void GetWriterBasedOnSomeCondition()
    {
        Dictionary<string, IWriter> writers = ...ToDictionary(x => x.Name);
        var choice = Console.ReadLine();
        return writers[choice];
    }
    
