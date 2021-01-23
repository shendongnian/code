    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Hotel_Check_In
    {
        class Program
        {
            static void Main(string[] args)
            {
                string lead = "JohnSmith";
                Room room = Room.rooms.AsEnumerable()
                    .Where(x => x.LeadName.LeadName == lead).FirstOrDefault();
            }
        }
        public class Room
        {
            public static List<Room> rooms = null;
            public int RoomNumber;
            public string RoomType;
            public string SmokingAllowed;
            public Boolean booked;
            public Guest LeadName;
            public Room(int numberOfRooms)
            {
                for (int i = 1; i <= numberOfRooms; i++)
                {
                    Room newRoom = new Room();
                    rooms.Add(newRoom);
                    newRoom.RoomNumber = i;
                }
            }
        }
        public class Guest
        {
            public string LeadName;
            public int roomNumber;
            public Guest(string name, int roomN)
            {
                LeadName = name;
                roomNumber = roomN;
            }
        }    
    }
