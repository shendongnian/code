    [HttpPost]
    public JsonResult AvailTimes(Guid practiceId, Guid opticianId, string date )
    {
        var timesList = db.Bookings
               .Where(a => a.PracticeId == practiceId &&
                      a.OpticianId ==opticianId &&)
                      a.isAvail != false &&);
         if (!string.IsNullOrWhiteSpace(date)) {
           System.Globalization.CultureInfo yourCulture =
             new System.Globalization.CultureInfo("pt-BR"); //example
           DateTime yourDate = DateTime.Parse(date, yourCulture);
            timesList = timesList.Where(i => i.Date == yourDate);
         }
         
        var final = timesList.Select(a => new
        {
            Value = a.TimeId,
            Text = a.Time.AppointmentTime
        }).ToList();
        return Json(final);
    }
