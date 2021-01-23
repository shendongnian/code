     public class RoomCollection : IDictionary<int, string>
    {
        private Dictionary<int, string> roomCollection = new Dictionary<int, string>();
        //Add modified version of Add()
        public void Add(Room room)
        {
            //Do something to efficiently check whether room already exists
            this.Add(room.UserId, room.Name);
        }
        public void Add(int key, string value)
        {
            //Checking can be done here
            if (this.roomCollection.ContainsKey(key))
            {
                this.roomCollection[key] = value; //Overwrite values
            }
            else
            {
                this.roomCollection.Add(key, value); //Create new item
            }
        }
        //Modify other functionalities to your own liking
        public bool ContainsKey(int key)
        {
            return this.roomCollection.ContainsKey(key);
        }
        public ICollection<int> Keys
        {
            get { throw new NotImplementedException(); }
        }
        public bool Remove(int key)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(int key, out string value)
        {
            throw new NotImplementedException();
        }
        public ICollection<string> Values
        {
            get { throw new NotImplementedException(); }
        }
        public string this[int key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public void Add(KeyValuePair<int, string> item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(KeyValuePair<int, string> item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(KeyValuePair<int, string>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get { throw new NotImplementedException(); }
        }
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
        public bool Remove(KeyValuePair<int, string> item)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<KeyValuePair<int, string>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public class Room
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
    public class TestCollection
    {
        public void Test()
        {
            Room r1 = new Room();
            r1.UserId = 1;
            r1.Name = "Room One";
            Room r2 = new Room();
            r2.UserId = 2;
            r2.Name = "Room Two";
            RoomCollection roomCollection = new RoomCollection();
            roomCollection.Add(r1);
            roomCollection.Add(r2);
            foreach (int roomId in roomCollection.Keys)
            {
                Console.WriteLine("Room number: {0} - Room name: {1}", roomId, roomCollection[roomId]);
            }
        }
    }
