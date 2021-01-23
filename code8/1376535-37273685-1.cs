    public void AddRoom(String id, String name, String description)
    {
        // Note that the rooms variable must be accessible inside your method
        rooms.Add(id, new Room(name, description));
    }
