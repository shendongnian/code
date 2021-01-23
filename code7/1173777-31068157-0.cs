    private void txtbox_BattMmnt_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back /*|| e.KeyChar == (char)5*/ || e.KeyChar == 46)
        {
            e.Handled = false;
        }
        else
        {
            e.Handled = true;
            MessageBox.Show("Please Enter Only Numeric Value", "Error", MessageBoxButtons.OK);
            return;//return if it is not numeric.
        }
        double i = 0;
        Double.TryParse(txtbox_BattMmnt.Text, out i);
        if (i <= 2.9 || i >= 3.35)
        { e.Handled = false; }
        else
        {
            e.Handled = true;
            MessageBox.Show("Please Enter Only from 2.9 to 3.35", "Error", MessageBoxButtons.OK);
        }
    }
