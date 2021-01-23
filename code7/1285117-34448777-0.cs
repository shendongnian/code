        [HttpPost]
        public IHttpActionResult BlockAppointment(Appointment appointment) {
            try {
                return base.Ok(this.AppointmentScheduler.BlockAppointment(appointment));
            } catch (Exception exception) {
                return base.InternalServerError(exception);
            }
        }
