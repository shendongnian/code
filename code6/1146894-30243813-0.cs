    System.DateTime toSerialize;
    long longDays = toSerialize.Ticks / System.TimeSpan.TicksPerDay;
    // Safe since (DateTime.MaxValue - DateTime.MinValue).Days << Int32.MaxValue
    int days = (int)longDays; 
    // Serializes `days` however you would serialize any other int
