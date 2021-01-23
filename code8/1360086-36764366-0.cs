    [DisplayName("Booking Time"), Column("bookingTime"), NotNull]
    public DateTime BookingTime
    {
        get { return Fields.BookingTime; }
        set { Fields.BookingTime = value; }
    }
