        internal class SlaveObj
    {
        private MainObj owner;
        private readonly int field1;
        private readonly string field2;
        public SlaveObj(MainObj parent)
        {
            this.owner = parent;
        }
        public int GetFieldID(int askerID)
        {
            if (askerID != owner.ID) return field1;
            return 0;
        }
    }
    class MainObj
    {
        public int ID;
        List<SlaveObj> slaves = new List<SlaveObj>();
        public int GetFieldID(MainObj other)
        {
            return other.slaves[0].GetFieldID(this.ID);
        }
        public MainObj(int id)
        {
            this.ID = id;
        }
    }
