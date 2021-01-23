    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            textBox2.AppendText(textBox1.Text.TrimEnd() + "\n"); //TrimEnd() removes trailing white-space characters.
            textBox1.Text = "";
            e.SuppressKeyPress = true; //Do not pass the Enter key press onto the TextBox.
        }
    }
