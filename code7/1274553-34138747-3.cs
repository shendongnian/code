    public static class Extensions
    {
        public static appointment ToAppointment(this AppointmentViewModel appointmentViewModel)
        {
            var result = new appointment
            {
                 appointment_id = appointmentViewModel.appointment_id;
                 // Copy all other properties here
                 ...
            };
            return result;        
        }
    }
    
    [HttpPost]
    public ActionResult Book(AppointmentViewModel appoint)
    {
        if(ModelState.IsValid)
        {
            // Map you view model to the model
            var appointment = appoint.ToAppointment();
            
            // Get you selected schedul from the database using either foreighn key either navigation property
            var schedule = db.schedules.FirstOrDefault(sched => sched.Id == appoint.SelectedScheduleId);
            appointment.schedule = schedule;
           
            db.appointments.Add(appointment);
            db.SaveChanges();
        }
        return RedirectToAction("Booked", "Home");
    }
