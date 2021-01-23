    class MobOwner
    {
        public string Name { get; private set; }
        public List<string> Mobiles { get; private set; }
        // constructor
        public MobOwner(string name, List<string> mobiles)
        {
            Name = name;
            Mobiles = mobiles;
        }
    }
