    private void butto1_Click (object sender, EventArgs e)
    {
         MessageBox.Show ("Button Clicked!");
         
         // And this two line:
         MessageBox.Show(radioButton1.Checked.ToString()); // true or false?
         MessageBox.Show(radioButton2.Checked.ToString()); // true or false?
    }
