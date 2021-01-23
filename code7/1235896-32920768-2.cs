    DateTime time;
    try
    {
        time = ...;
    }
    catch (FormatException)
    {
        Console.WriteLine("Wrong date and time format!");
        return; // Or some other way of getting out of the method,
                // otherwise time won't be definitely assigned afterwards
    }
