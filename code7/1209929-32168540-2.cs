    public class School 
    {
        public School(string schoolStr, bool IsFirstSchool = false, bool IsLastSchool = false) 
        {
             int nrOfRooms = IsFirstSchool || IsLastSchool ? 1 : 2;
             //set number of rooms in room class
             Rooms = new List<Room>();
             Rooms.Add(new Room(someVal));
             Rooms.Add(new Room(someVal));
        }
        public List<Room> Rooms {get; set; }
    }
