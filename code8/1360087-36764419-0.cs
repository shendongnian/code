    [DisplayName("Booking Time"), Column("bookingTime"), NotNull]
    public DateTime BookingTime
    {
        get { return this.Fields.BookingTime; }
        set { this.Fields.BookingTime = value; }
    }
