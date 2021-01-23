    private void btnRegister_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtPatientName.Text))
        {
            MessageBox.Show("You did not enter anything, please enter the patients name.");
        }
        else
        {
            //do something to get reference to your form...
            //for example, you can create a new form, or get the form by its id
            CentralStation centralStation = new CentralStation();
            centralStation.centralModule1.lblPatientName = txtPatientName.Text;
            //and then do something else...
            centralStation.Show();
        }
    }
