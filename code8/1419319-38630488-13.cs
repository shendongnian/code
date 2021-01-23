    public class Champion
    {
         public int id { get; set; }
         public bool active { get; set; }
         public bool botEnabled { get; set; }
         public bool freeToPlay { get; set; }
         public bool botMmEnabled { get; set; }
         public bool rankedPlayEnabled { get; set; }
    }
    public class ChampionList
    {
         public List<Champion> champions { get; set; }
    }
