    class DbItem
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public Prezime { get; set; }
    
        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
