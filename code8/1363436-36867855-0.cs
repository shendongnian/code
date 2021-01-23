    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace Test {
        static class Program {
            static void Main() {
    
                string json = @" {
     	""Summoner_Id"": [{
     		""name"": ""Fiora's Inquisitors"",
     		""tier"": ""GOLD"",
     		""queue"": ""RANKED_SOLO_5x5"",
     		""entries"": [{
     			""playerOrTeamId‌​"": ""585709"",
     			""playerOrTeamName"": ""AP Ezreal Mid"",
     			""division"": ""IV"",
     			""leaguePoints"": 61,
     			""wins"": 175,
     			""losses"": 158,
     			""isHotStreak"": false,
     			""isVeteran"": false,
     			""isFreshBlood"": false,
     			""isInactive"": false
     		}]
     	}]
     }";
    
                var root = JsonConvert.DeserializeObject<RootObject>(json);
                Console.WriteLine(root.Summoner_Id);
            }
        }
    
        public class Entry {
            public string playerOrTeamId { get; set; }
            public string playerOrTeamName { get; set; }
            public string division { get; set; }
            public int leaguePoints { get; set; }
            public int wins { get; set; }
            public int losses { get; set; }
            public bool isHotStreak { get; set; }
            public bool isVeteran { get; set; }
            public bool isFreshBlood { get; set; }
            public bool isInactive { get; set; }
        }
    
        public class SummonerId {
            public string name { get; set; }
            public string tier { get; set; }
            public string queue { get; set; }
            public List<Entry> entries { get; set; }
        }
    
        public class RootObject {
            public List<SummonerId> Summoner_Id { get; set; }
        }
    }
    
