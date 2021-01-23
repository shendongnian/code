    [Serializable]
    public class Ship
    {
    
        public struct Stat
        {
            public int StatValue { get; set; }
            public int StatLast { get; set; }
    
            public Stat(int statValue, int statLast)
            {
                StatValue = statValue;
                StatLast = statLast;
            }
        }
    
    public int a = 0;
    public string Name { get; set; }
    public string Owner { get; set; }
    [SerializeField]
    public Dictionary<string, Stat> Aim { get; set; }
    [SerializeField]
    public Dictionary<string, Stat> Dodge { get; set; }
    [SerializeField]
    public Dictionary<string, Stat> EmPower { get; set; }
    [SerializeField]
    public Dictionary<string, Stat> HullPoint { get; set; }
    [SerializeField]
    public Dictionary<string, Stat> CorePower { get; set; }
    [SerializeField]
    public Dictionary<string, Stat> Reaction { get; set; }
    public string Size { get; set; }
    public int CurrentHullPoint { get; set; }
    public int CurrentCorePower { get; set; }
    ...
