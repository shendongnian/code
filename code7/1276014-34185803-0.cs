    public class DataBase
    {
       public string Identifier { get; set; }
       public string Key { get; set; } 
    }
    
    public IEnumerable<DataBase> FindInstancesByKey(IEnumerable<DataBase> data, string key)
    {
       return data.Where(d => d.Key == key);
    }
    public void Main()
    {
       // Deserialize the data
       var data = Deserialize();
       var instances = FindInstancesByKey(data, "mykey");
       Console.WriteLine(instances.Select(x => x.Instance);
    }
