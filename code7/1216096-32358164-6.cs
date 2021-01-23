    for( var index = 0; index < businessHolidays.length; index++) {
       var holiday = businessHolidays[index];
       if (holiday.Date >= StartDate.Date && holiday.Date <= EndDate.Date) {
          EndDate.AddDays(1);
       }
    }
