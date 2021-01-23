    public static bool GetDuplicates(IEnumerable<IBooking> pBookings)
    {
        //does pBookings contain items with duplicate BookingId values?
        return pBookings.GroupBy(b => b.BookingId).Any(g => g.Count() > 1);
    }
