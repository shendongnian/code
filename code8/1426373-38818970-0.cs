    private async void BookAppointmentCommandExecute() {
      Debug.WriteLine("VM Start");
      IsBusy = true;
      await Service.BookAppointment(Appointment.ID, PatientID);
      IsBusy = false;
      Debug.WriteLine("VM Done");
    }
    
    
    [OperationContract]
    public async Task BookAppointment(int appointmentID, int patientID) {
      Debug.WriteLine("Svc Start");
      await Task.Delay(1000);
      await AppointmentsServiceLogic.BookAppointment(appointmentID, patientID);
      Debug.WriteLine("Svc Done");
    }
