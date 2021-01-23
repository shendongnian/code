        [ForeignKey("BankId")]
        [InverseProperty("ForeclosureActionHeaders")]
        public virtual Bank Bank { get; set; }
        public virtual int BankId { get; set; }
        [ForeignKey("AssignedToBankId")]
        [InverseProperty("AssignedToBankForeclosureActionHeaders")]
        public virtual Bank AssignedToBank { get; set; }
        public virtual int AssignedToBankId { get; set; }
