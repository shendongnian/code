    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int strengthMod { get; set; }
        public int toughnessMod { get; set; }
    }
    
    public class Room
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Item> items { get; set; }
        public List<object> entities { get; set; }
        public string northExit { get; set; }
        public string southExit { get; set; }
        public string eastExit { get; set; }
        public string westExit { get; set; }
    }
    
    public class Game
    {
        public List<Room> Rooms { get; set; }
    }
