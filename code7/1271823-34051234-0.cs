    DateTime minDate = new DateTime(mydate.Date.Year, mydate.Date.Month, mydate.Date.Second);
    DateTime maxDate = minDate.AddSeconds(86399);
    
    var entity = dbContext.MyTable
                          .Where(w => w.PId = 3 && w.CreatedOn >= minDate && w.CreatedOn <= maxDate).First();
