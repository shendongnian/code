        public Guid Id { get; set; }
        public string RowNumber { get; set; }
        public int SeatNumber { get; set; }
        
        public virtual Reservation Reservation { get; set; }
    }
