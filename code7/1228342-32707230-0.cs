    [HttpPost]
    public ActionResult Update(UpdateAppointment UAForm){
         UpdateAppointment ua = new UpdateAppointmentBll().Find(UAForm.Id);
         ua.StartTime = UAForm.StartTime;
         //so no...
         if(UAForm.MemberId != null)
            ua.MemberId = UAForm.MemberId;
    
         new UpdateAppointmentBll().Save(ua);
    
         return View();
    }
