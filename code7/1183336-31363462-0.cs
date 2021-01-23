    public class Entity 
    {
        public string Type;
        public string Spawnzone;
        public string _Class;
        public string Defaultlevel;
        public string Maxlevel;
        public string Trait;
        public string str;
        public string agi;
        public string dex;
        public string hel;
        public string man;
        
        public Entity(string Type, string Spawnzone, string _Class, int Defaultlevel, int Maxlevel, string trait, int str, int agi, int dex, int hel, int man) 
        {
            this.Type = Type;
            this.Spawnzone = Spawnzone;
            this._Class = _Class;
            this.Defaultlevel = Defaultlevel;
            this.Maxlevel = Maxlevel;
            this.Trait = trait;
            this.str = str;
            this.agi = agi;
            this.dex = dex;
            this.hel = hel;
            this.man = man;
        }
    }
    public class Enemy 
    {
        public string[] droplist;;
        public int defaultgold;
        public string weaknesses;
        public string resistances;
        public string[] taunts;
        public string aggro;
        public string critchance;
        public string threshold;
        public Enemy(string[] Droplist, int Defaultgold, string Weaknesses, string Resistances, string[] Taunts, string Aggro, string Critchance, string Threshold, string Name, string Type, string Spawnzone, string _Class, int Defaultlevel, int Maxlevel, string trait, int str, int agi, int dex, int hel, int man ) 
        : base(Type, Spawnzone, _Class, Defaultlevel, Maxlevel, trait, str, agi, dex, hel, man)
        {
            droplist = Droplist;
            defaultgold = Defaultgold;
            weaknesses = Weaknesses;
            resistances = Resistances;
            taunts = Taunts;
            aggro = Aggro;
            critchance = Critchance;
            threshold = Threshold;
        }
}   
