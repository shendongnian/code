        public class Room
        {
        	public int Id { get; set; }
            public string Name { get; set; }
        }
        
        public class ViewModel
        {
            public Room room {get;set;}
            public Dictionary <string, Room> rooms { get; set; }
        }
