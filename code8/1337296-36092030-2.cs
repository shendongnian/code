    [DataContract]
    public class Ship
    {
    
        // Must use parameterless constructor for serialization
        public Ship()
        {
         Aim = new Dictionary<string, Stat>();
         Dodge = new Dictionary<string, Stat>();
         EmPower = new Dictionary<string, Stat>();
         HullPoint = new Dictionary<string, Stat>();
         CorePower = new Dictionary<string, Stat>();
         Reaction = new Dictionary<string, Stat>();
        }
    
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
     [DataMember]
    public Dictionary<string, Stat> Aim { get; set; }
     [DataMember]
    public Dictionary<string, Stat> Dodge { get; set; }
     [DataMember]
    public Dictionary<string, Stat> EmPower { get; set; }
     [DataMember]
    public Dictionary<string, Stat> HullPoint { get; set; }
     [DataMember]
    public Dictionary<string, Stat> CorePower { get; set; }
     [DataMember]
    public Dictionary<string, Stat> Reaction { get; set; }
    public string Size { get; set; }
    public int CurrentHullPoint { get; set; }
    public int CurrentCorePower { get; set; }
    ...
