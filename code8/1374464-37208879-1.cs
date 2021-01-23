        public Guid Id { get; set; }
        .....(your reservation properties)
        public Guid SeatId { get; set; }
        public virtual Seat Seat { get; set; }
    }
