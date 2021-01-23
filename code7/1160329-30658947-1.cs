    string mobileNumber = "+8801000000000";
    if (new Regex(@"^(?:\+?88|0088)?01[15-9]\d{8}$").IsMatch(mobileNumber)){
        MessageBox.Show("Mobile number is valide", "All information is required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    else{
         MessageBox.Show("Mobile number is not valide", "All information is required", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
