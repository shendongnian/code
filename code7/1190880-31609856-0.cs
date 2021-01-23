    public class Investor // List
    {
    public int iID { get; set; }
    public string iName { get; set; }
    public string iDisplayName { get; set; }
    public string iArea { get; set; }
    }
    public class Area // List
    {
    public int aID { get; set; }
    public string aName { get; set; }
    public string aDisplayName { get; set; }
    }
    public class Data
    {
    public List<Investor> Investor { get; set; }
    public List<Area> Area { get; set; }
    }
