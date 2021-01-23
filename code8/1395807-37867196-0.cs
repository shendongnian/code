    int myCustomDate = 1606016;  // June 16, 16
    int day = myCustomDate % 1000;
    int month = (myCustomDate / 1000) % 100;
    // Somehow you have to give it a century. Since you're using 2-digit years,
    // I'll assume current century.
    int year = 2000 + (myCustomDate / 100000);
    DateTime dt = new DateTime(year, month, day);
    dt.AddDays(1);
    // then convert back to your number
    int newCustomDate = (100000 * dt.Year) + (1000 * dt.Month) + dt.Day;
