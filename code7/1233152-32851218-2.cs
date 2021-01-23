    async void OnUpdate(object sender, EventArgs e)
    {
        string tempUser = globalPatient.Username;
        string tempPin = globalPatient.PIN;
        patUpdate = patientManager.GetPatientByUsername (tempUser, tempPin).Result;
        App.PatientDB.DeletePatient(tempID);
        App.PatientDB.AddNewPatient (patUpdate, tempPin);
        MyCurrenViewModel.vitals = patUpdate.Vitals; // Replace old vitals
        DisplayAlert ("Updated", "Your information has been updated!", "OK");
    }
