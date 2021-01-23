    protected void doctorDetails_Click(object sender, EventArgs e)
    {
        // Clear all properties each time the button is clicked
        validationMessage.InnerText = string.Empty;
        txtDoctorName.BorderColor = System.Drawing.Color.Black;
        txtGender.BorderColor = System.Drawing.Color.Black;
        
        if (txtDoctorName.Text.Trim().Length == 0 )
        {
        ...
    }
