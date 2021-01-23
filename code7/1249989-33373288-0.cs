    private void txtSearchTerm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Down)
        {
            if (Results.SelectedIndex < (Results.Items.Count - 1))
                Results.SelectedIndex++;
            e.Handled = true;
        }
        else if (e.KeyCode == Keys.Up)
        {
            if (Results.SelectedIndex > 0)
                Results.SelectedIndex--;
            e.Handled = true;
        }
    }
