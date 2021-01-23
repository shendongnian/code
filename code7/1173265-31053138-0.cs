    private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.V)
        {
            dateTimePicker1.Value = DateTime.Parse(Clipboard.GetText());
            e.Handled = true;
        }
    }
