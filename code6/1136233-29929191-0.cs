    int patientId;
    if(int.TryParse(txtPatientID.Text, out patientId))
    {
        this.GetPatient(patientId);
        if (patient == null)
        {
            MessageBox.Show("No patient found with this ID. " + "Please    try again.", "Patient Not Found");
             this.ClearControls(); 
        }
        else
            this.DisplayPatient(); 
    }
