    public static Room saveTheatherRoom(Room theatherRoom)
    {
            using (var db = new ThetherDBContext())
            {
                db.Rooms.Add(theatherRoom);                                
                db.SaveChanges();
                return theatherRoom;
            }
    }
