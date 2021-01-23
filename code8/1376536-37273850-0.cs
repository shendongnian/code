        public struct Room
        {
            public String Name;
            public String Desc;
        }
        Dictionary<string, Room> World = new Dictionary<string, Room>();
        public void AddRoom(String id, String name, String description)
        {
            Room room = new Room() { Name = name, Desc = description };
            World.Add(id, room);
        }
    AddRoom("kitchen1", "Old Kitchen", "A dark, cold, old kitchen");
