    [HttpPost]
    public JsonResult AvailTimes(Guid practiceId, Guid opticianId, DateTime? date )
    {
        var timesList = db.Bookings
               .Where(a => a.PracticeId == practiceId &&
                      a.OpticianId ==opticianId &&)
                      a.isAvail != false &&);
         if (date.HasValue)
            timesList = timesList.Where(i => i.Date == date.Value);
         
        var final = timesList.Select(a => new
        {
            Value = a.TimeId,
            Text = a.Time.AppointmentTime
        }).ToList();
        return Json(final);
    }
