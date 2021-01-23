    var testIDs = new int[] { 1, 3 };
    if (testIDs == null)
    {
        var test = session.All<VendorBooking>()
            .ToList();
    }
    else
    {
        var test = session.All<VendorBooking>(x => testIDs.Contains(x.VendorServiceID))
           .ToList();
    }
