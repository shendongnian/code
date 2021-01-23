            var t = JsonConvert.DeserializeObject<Families>("json");
            var match = t.theFamilies.Where(a => a.parent2 == "Mary").ToList();
            public class Families
            {
                public List<Family> theFamilies { get; set; }
            }
            public class Family
            {
                public string parent1 { get; set; }
                public string parent2 { get; set; }
                public string child1 { get; set; }
            }
