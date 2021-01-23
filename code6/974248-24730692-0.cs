    private void done_Click(object sender, EventArgs e)
    {
        if (datePicker != null)
            Items.Over50Date = datePicker.Value != null ? datePicker.Value : DateTime.Now;
        NavigationService.GoBack();
    }
