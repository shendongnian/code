    public class Authority
    {
        public int ID { get; set; }
        public string Term { get; set; }
        public virtual ICollection<Authority> Broader { get; set; }
        public virtual ICollection<Authority> Narrower { get; set; }
        public virtual ICollection<Authority> Equivalent { get; set; }
        public virtual ICollection<Authority> Related { get; set; }
        public virtual ICollection<Authority> Use { get; set; }
        public virtual ICollection<Authority> Usefor { get; set; }
        public Authority()
        {
            Broader = new HashSet<Authority>();
            Narrower = new HashSet<Authority>();
            Equivalent = new HashSet<Authority>();
            Related = new HashSet<Authority>();
            Use = new HashSet<Authority>();
            Usefor = new HashSet<Authority>();
        }
    }
