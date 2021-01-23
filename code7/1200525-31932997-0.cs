    protected void btnMyButton_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid) return; // Handle rdpMyDateTimePicker not having a selected date by using a RequiredFieldValidator control
        if (rdpMyDateTimePicker.SelectedDate == null) return; // Proper form validation should always prevent this being null
            
        var formattedDate = Convert.ToDateTime(rdpMyDateTimePicker.SelectedDate).ToString("yyyy-MM-dd");
            
        // Now insert the formattedDate string as a parameter into your database query
    }
