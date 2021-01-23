    public class FacetCounts
    {
        public class Facet_Ranges
        {
            public class CreatedAt
            {
                public List<string> counts 
                { 
                  get
                  {
                    return Counts
                      .SelectMany(pair => new[]{pair.Key, pair.Value.ToString()})
                      .ToList();
                  }
                  set
                  {
                    var pairs = new Dictionary<string, int>(); 
                    for (var i = 0; i < value.Length / 2; ++i)
                    {
                      pairs[value[2*i]] = int.Parse(value[2*i+1]);
                    }
                    this.Counts = pairs;
                  }
                }
                [JsonIgnore]
                public Dictionary<string, int> Counts {get;set;}
            }
            public CreatedAt createdat { get; set; }
        }
        public Facet_Ranges facet_ranges { get; set; }
    }
