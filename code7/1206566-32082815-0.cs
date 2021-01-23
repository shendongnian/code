    using System;
    
    public class Summoner
    {
        public Amarasul amarasul { get; set; }
    
        public void Ver()
        {
            Console.WriteLine(amarasul.id);
            Console.WriteLine(amarasul.name);
            Console.WriteLine(amarasul.profileIconId);
            Console.WriteLine(amarasul.revisionDate);
            Console.WriteLine(amarasul.summonerLevel);
        }
    }
    
    public class Amarasul
    {
        public int id { get; set; }
        public string name { get; set; }
        public int profileIconId { get; set; }
        public int summonerLevel { get; set; }
        public long revisionDate { get; set; }
    }
