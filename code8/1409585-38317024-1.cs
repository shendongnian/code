    // Is more than one non-empty?
    var multipleWithContent = Controls.Cast<TextBox>().Count(t => String.IsNullOrWhiteSpace(t.Text)) > 1;
    // Handle accordingly
    if(multipleWithContent)
    {
         MessageBox.Show("Can Only Search From One Textbox");
    }
