    public class Room
    {
        public bool IsAvailable {get; set;}
        public RoomType RoomType {get; set;}
        public int RoomNo {get; set;}
        public int Floor {get; set;}
        public string RoomName {get; set;}
    }
    
    public enum RoomType
    {
         Single,
         Double,
         Twin,
         King,
         HoneymoonSuite
    }
    
    public class RoomManager
    {
           List<Room> AllRooms = new List<Room>();
           AllRooms.Add(new Room(){ RoomType=RoomType.Single, 
                                    RoomNo=1, 
                                    Floor=1, 
                                    RoomName="A101", 
                                    IsAvailable=true});
           AllRooms.Add(new Room(){ RoomType=RoomType.Double, 
                                    RoomNo=2, 
                                    Floor=1, 
                                    RoomName="A102", 
                                    IsAvailable=false});
           AllRooms.Add(new Room(){ RoomType=RoomType.HoneyMoonSuite, 
                                    RoomNo=1, 
                                    Floor=2, 
                                    RoomName="A201", 
                                    IsAvailable=true});
    
    
    }
