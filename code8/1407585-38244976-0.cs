    class MobOwner
    {
        public string Name { get; set; }
        public List<string> Mobiles { get; set; }
        public MobOwner() {
            this.Mobiles = new List<string>();
        }
    }
