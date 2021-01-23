    //Assuming it's EntityFramework
    public IEnumerable<Room> GetRoomsByFloor(int floorId)
    {
        Database.Room.Where(x => x.FloorId == floorId).ToList();
    }
