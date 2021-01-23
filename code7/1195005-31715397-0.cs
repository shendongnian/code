    public class RegKey
    {
       public string Name { get; set; }
       public List<CEKeys> Key { get; set; }
       public RegKey()
       {
            Key = new List<CEKeys>();
       }
    }
