    private async void BookAppointmentCommandExecute() {
        Debug.WriteLine("VM Start");
        IsBusy = true;
        await Service.BookAppointment(Appointment.ID, PatientID); //as I've changed the return type of the method below, I can now directly await it
        IsBusy = false;
        Debug.WriteLine("VM Done");
    }
    
    //the method should return Task, so you can use the await keyword to wait for its completion
    //I've marked the method with the async keyword so I can use the await keyword within
    [OperationContract]
    public async Task BookAppointment(int appointmentID, int patientID) {
        Debug.WriteLine("Svc Start");
        await Task.Delay(1000);
        await AppointmentsServiceLogic.BookAppointment(appointmentID, patientID);
        Debug.WriteLine("Svc Done");
    }
