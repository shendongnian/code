    class Reference
    {
        public Reference()
        {
            Printers = new HashSet<Printers>();
            Pc = new HashSet<Pc>();
            Users = new HashSet<Users>();
        }
        public DateTime Date { get; set; }
        public ICollection<Printers> Printers { get; set; }
        public ICollection<Pc> Pc { get; set; }
        public ICollection<Users> Users { get; set; }
    }
