    class Room
    {
        // same as yours
    }
    class Building
    {
        public List<Room> Rooms { get; set; }
        public Building()
        {
            Rooms = new List<Room>();
            Rooms.Add(new Room());
            Rooms.Add(new Room());
            // get "room #x" -> var room = objBuilding.Rooms[x];
            // get "room #x in building #i" -> var room = objStreet.Buildings[i].Rooms[x];
        }
    }
    class Street
    {
        public List<Building> Buildings { get; set; }
        public Street ()
        {
            Buildings = new List<Building>();
            Buildings.Add(new Building());
            Buildings.Add(new Building());
            Buildings.Add(new Building());
            Buildings.Add(new Building());
            // get "building #i" -> var building = objStreet.Buildings[i];
        }
    }
