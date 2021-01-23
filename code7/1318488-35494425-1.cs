    DateTime first = new DateTime(1, 1, 1, 11, 15, 0);
    List<DateTimeOffset> list = new List<DateTimeOffset>();
    list.Add(new DateTimeOffset(first));
    list.Add(new DateTimeOffset(first.AddMinutes(15)));
    list.Add(new DateTimeOffset(first.AddMinutes(30)));
