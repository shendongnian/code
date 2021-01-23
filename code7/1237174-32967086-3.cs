    public class Yaku
    {
        public string Name { get; }
        public int    Han  { get; }
        public Yaku(string name, int han)
        {
            Name = name;
            Han  = han;
        }
        public override string ToString()
        {
            return Name;
        }
    }
