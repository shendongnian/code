    public class Radio
    {
        private HashTable<string, EventHandler<ISound>> rooms = new ...;
        public void RegisterRoom(string room, EventHandler<ISound> onSound)
        {
            rooms[room] = onSound;
        }
        public void UnregisterRoom(string room)
        {
            rooms.Remove(room);
        }
        public void PlayRoom(string room)
        {
            EventHandler<ISound> onSound;
            if (rooms.TryGetValue(room, out onSound))
            {
                onSound(this, new BuildingSpeaker() { sound = "Test" });
            }
        }
        
        public void PlayAllRooms()
        {
            if (rooms.Count == 0)
            {
                return;
            }
            var speaker = new BuildingSpeaker() { sound = "Test All Rooms" };
            foreach (var room in rooms)
            {
                room.Value(this, speaker);
            }
        }
    }
