    public class Zone {
         // UserID as key, type as value.
         public Dictionary<int, int> Users { get; set; }
         
         public Zone {
              Users = new Dictionary<int, int>();
         }
         public void AddUser(int userID, int typeID)
              Users.Add(userID, typeID);
         }
    }
