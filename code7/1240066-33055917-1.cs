    if(!DateTime.TryParse(txtDate.Text, out p.DateBirth))
    {
        // The parse failed.
        MessageBox.Show("Invalid date");
    }
