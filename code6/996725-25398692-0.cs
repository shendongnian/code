    public class House
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public virtual List<Room> rooms { get; set; }
    
        public House()
        {
            rooms = new List<Room>();
        }
    }
    
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int roomNumber { get; set; }
        public int HouseId {get; set; }
        [ForeignKey("HouseId")]
        public virtual House house { get; set; }
    }
