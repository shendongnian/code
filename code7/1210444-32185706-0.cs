    public static class Settings
    {
        public static Dictionary<string, Task<Room>> informationHolder = 
            new Dictionary<string, Task<Room>>();
    }
    public ActionResult Index(){
        foreach (var room in roomList)
        {
            int index = roomList.IndexOf(room);
            Settings.informationHolder.Add(
                roomList[index].Email, 
                System.Threading.Tasks.Task.Run(() => loadRoomData(roomList[index].Email)));
            }
        }
