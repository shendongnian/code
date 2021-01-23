    // Are all TextBox Controls empty?
    var allEmpty = Controls.Cast<TextBox>().All(t => String.IsNullOrWhiteSpace(t.Text));
    // Handle accordingly
    if(allEmpty)
    {
         MessageBox.Show("Please Input a Value");
    }
