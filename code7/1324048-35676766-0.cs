    public bool Load(string fileName)
    {
        string appointmentData = string.Empty;
        using (StreamReader reader = new StreamReader(fileName))
        {
            while((appointmentData = reader.ReadLine()) != null)
            {
                if(!string.IsNullOrWhiteSpace(appointmentData))
                {
                    if(appointmentData[0] == 'R')
                        this.Add(appointment = new RecurringAppointment(appointmentData));
                    else
                        this.Add(appointment = new Appointment(appointmentData));
                }
            }
            return true;
        }
    }
