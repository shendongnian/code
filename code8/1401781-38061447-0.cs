        public ActionResult AppointmentsView(int id)
        {
            using (var context = new WaysToWellnessDB())
            {
                IEnumerable<AppointmentDiary> appointments = context.AppointmentDiaries.Include(p => p.AccountUser).Include(p => p.AttendedStatus).Include(p => p.Location).Where(a => a.PatientId == id).ToList();
                return PartialView("/Views/Patient/Appointment/_ViewAppointments.cshtml", appointments);
            }
        }
