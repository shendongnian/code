    public class Club : IEntity
    {
        public string Id { get; set; }
    	public string Name { get; set; }
    	public string Country { get; set; }
    	public string Place { get; set; }
    	public long ClubId { get; set; }
        public string Access { get; set; } = "read";
        public List<ClubMember> Members { get; set; }
        
        public void PopulateFrom(IDictionary<string, object> prop)
        {
            Name = prop.GetOrDefault<string>("name");
            Country = prop.GetOrDefault<string>("country");
            Place = prop.GetOrDefault<string>("place");
            ClubId = prop.GetOrDefault<long>("club_id");
            Access = prop.GetOrDefault<string>("access");
            Members = ParseMembers(prop["members"]);
        }
    
    
        public IDictionary<string, object> ToDictionary()
        {
    
            return new Dictionary<string, object>
            {
                { "club_id", ClubId },
                { "name", Name },
                { "country", Country },
                { "place", Place },
                { "access", Access },
                { "members", Members}
            };
        }
    
    }
 
