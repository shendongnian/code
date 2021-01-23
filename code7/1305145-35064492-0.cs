    public class occ
    {
        public List<Ktype> ktype { get; set;}
        public occ()
        {
            this.ktype = new List<Ktype>();
        }
    }
        
    public class Ktype
    {
        public datetime from    { get; set; }
        public datetime to      { get; set; }
        public flag     bool    { get; set; }
    }
