    class MobOwner
    {
        public string Name { get; set; }
        public List<string> Mobiles { get; set; }
        public MobOwner(string Name, params string[] Mobiles) 
        {
            this.Name = Name;
            this.Mobiles = new List<string>(Mobiles);
        }
    }
