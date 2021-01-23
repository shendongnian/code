    private void button_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();       // this will be your message
        // 1. Loop over all the controls in the form and collect the statuses.
        // (if you want to limit it to only some checkboxes you could put them 
        // in a gui container or array, and loop over yourContainer.Controls instead.)
        foreach (var cb in Controls)        
        {
            // append to string if this is a checkbox AND it is checked
            var c = cb as CheckBox;
            if (c != null && c.Checked)    
            {
                sb.Append(c.Text + "\n");  // ps "\n" is a new line in the message
            }
        }
        // 2. display the message if any checkbox was selected.
        var message = sb.ToString();
        if (!string.IsNullOrWhiteSpace(message)) // not empty?
            MessageBox.Show(message);
    }
