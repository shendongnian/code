    var hasDuplicates = roomBookings.ContainsDuplicates(item => item.bookingId);
    if(hasDuplicates)
    {
        Console.WriteLine("Duplicates found:");
        foreach (var duplicate in roomBookings.GetDuplicates(item => item.bookingId))
        {
            Console.WriteLine(duplicate);
        }
    }
