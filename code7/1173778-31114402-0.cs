      private void txtbox_BattMmnt_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtbox_BattMmnt = (TextBox)sender;
            double d; Double.TryParse(txtbox_BattMmnt.Text, out d);
            if ((d <= 2.8) || (d >= 3.36))
            {
                MessageBox.Show("Please Enter Only from 2.9 to 3.35", "Error", MessageBoxButtons.OK);
            }
            txtbox_BattMmnt.Text = String.Empty;
        }
