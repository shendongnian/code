    private void done_Click(object sender, EventArgs e)
    {
        if (datePicker != null)
        {
            if (datePicker.Value != null) 
            {
                Items.Over50Date = Convert.ToDateTime(datePicker.Value);
            }
        }
        NavigationService.GoBack();
    }
