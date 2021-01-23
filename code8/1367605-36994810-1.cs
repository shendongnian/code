    private void subbut_Click(object sender, EventArgs e)
    {
        // "textBox1" contains the text value for the filename
        string fileName = textBox1.Text;
        // This is the only missing piece that you need now. 
        // You are not going to get the value for the table name from the click event.
        // Instead you need to get it from the user input, i.e.; a textbox control.
        string tableName = tableTextBox.Text;
        // ...
    }
