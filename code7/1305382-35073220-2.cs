    private void btnRegBed1_Click(object sender, EventArgs e)
        {
            Hide();
            //here you pass your CentralStation into the patientRegister you are initiating by using "this"
            PatientRegister patientRegister = new PatientRegister(this);
            patientRegister.ShowDialog();
            this.Visible = false;
            Show();
        }
