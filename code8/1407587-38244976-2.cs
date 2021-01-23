    class MobOwner
    {
        public string Name { get; set; }
        public List<string> Mobiles { get; set; }
        public MobOwner(IEnumerable<string> values) {
            this.Mobiles = values.ToList();
        }
    }
