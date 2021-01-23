    public class RoomObjects 
    {
       public static Room room1 = new Room { Id = 1 }; 
       public static Room room2 = new Room();
       public static int room3 = 0; //Took int type for test that Room & Int32 type castings don't mess up while reflecting
    
       public List<Room> GetRoomObjects()
       {
           List<Room> availableRooms = new List<Room>();
    
           var allRoomFields = this.GetType().GetFields(); //GetProperties() in case of properties we want to reflect over.
    
           foreach (var roomFieldInfo in allRoomFields)
           {
               Room tempRoom = roomFieldInfo.GetValue(this) as Room; //Here Int32 field won't throw invalid cast exception while casting to Room type
    
               if (tempRoom != null)
               {
                   availableRooms.Add(tempRoom);
               }
           }
    
           return availableRooms;
       }
    }
