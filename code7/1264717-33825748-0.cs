        public IList<Agency> Agencies1 { get; set; }
        public IList<Agency> Agencies2 { get; set; }
        [NotMapped]
        public string AllAgencies
        {
            get
            {
                return Agencies1.Concat(Agencies2).ToList();
            }
        }
