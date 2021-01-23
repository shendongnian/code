    DateTime dateTime = DateTime.Now;
    Console.WriteLine("Original date/time: " + dateTime );
    int timeMsSinceMidnight = (int)dateTime.TimeOfDay.TotalMilliseconds;
    DateTime date = dateTime.Date; // Midnight.
    DateTime restoredTime = date.AddMilliseconds(timeMsSinceMidnight);
    Console.WriteLine("Restored date/time: " + restoredTime);
