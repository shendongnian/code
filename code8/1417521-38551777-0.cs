        public benedet()
        {
            this.bankdets = new HashSet<bankdet>();
            this.damagedets = new HashSet<damagedet>();
            this.imagedets = new HashSet<imagedet>();
        }
        public virtual ICollection<bankdet> bankdets { get; set; }
    
        public virtual ICollection<damagedet> damagedets { get; set; }
    
        public virtual ICollection<imagedet> imagedets { get; set; }
