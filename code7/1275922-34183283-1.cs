    var data = "[{\"User\": {\"Identifier\": \"24233\",\"DisplayName\": \"Commerce Test Student\",\"EmailAddress\": \"email@email.ca\",\"OrgDefinedId\": \"UniqueId1\",\"ProfileBadgeUrl\": null,\"ProfileIdentifier\": \"zzz123\"},\"Role\": {\"Id\": 153,\"Code\": null,\"Name\": \"Commerce Student\"}}]";
    public class User
    {
        public string Identifier { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string OrgDefinedId { get; set; }
        public object ProfileBadgeUrl { get; set; }
        public string ProfileIdentifier { get; set; }
    }
    
    public class Role
    {
        public int Id { get; set; }
        public object Code { get; set; }
        public string Name { get; set; }
    }
    
    public class RootObject
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
    var items = JsonConvert.DeserializeObject<List<RootObject>>(data);
