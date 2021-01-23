    private void enterCheck(object sender, KeyEventArgs e)  
    {
        if (e.KeyCode == Keys.Enter)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }
        else
        {
            e.Handled = true;
        }
    }
