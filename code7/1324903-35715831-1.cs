    public class RootObject
    {
        public Dictionary<string, Profile> profiles { get; set; }
        public string selectedProfile { get; set; }
    }
    public class Profile
    {
        public string name { get; set; }
        public string lastVersionId { get; set; }
    }
