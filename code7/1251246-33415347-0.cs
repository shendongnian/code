    public class Room {
        public int Id {get; set;}
        public List<Image> Images {get; set; }
    }
    public class Image {
        public Room Room {get; set; }
    }
