    public class Rootobject
    {
        public _Links _links { get; set; }
        public int count { get; set; }
        public Player[] players { get; set; }
    }
    public class _Links
    {
        public _Self _self { get; set; }
        public Team team { get; set; }
    }
    public class _Self
    {
        public string href { get; set; }
    }
    public class Team
    {
        public string href { get; set; }
    }
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public int jerseyNumber { get; set; }
        public string dateOfBirth { get; set; }
        public string nationality { get; set; }
        public string contractUntil { get; set; }
        public string marketValue { get; set; }
    }
