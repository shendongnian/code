        public benedet()
        {
            this.bankdets = new List<bankdet>();
            this.damagedets = new List<damagedet>();
            this.imagedets = new List<imagedet>();
        }
        public virtual List<bankdet> bankdets { get; set; }
      
        public virtual List<damagedet> damagedets { get; set; }
      
        public virtual List<imagedet> imagedets { get; set; }
    
    
