    public class School 
    {
        public School(string schoolStr, bool IsFirstSchool = false, bool IsLastSchool = false) 
        {
             int nrOfRooms = IsFirstSchool || IsLastSchool ? 1 : 2;
             Rooms = new List<Room>();
             var room = new Room(someVal);
             Rooms.Add(room);
             room = new Room(someVal);
             Rooms.Add(room);
        }
        public List<Room> Rooms {get; set; }
    }
