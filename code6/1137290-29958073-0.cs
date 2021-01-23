    private void textBox1_Validating(object sender, EventArgs e)
    {
        txtchance.Text = tries.ToString();
        if (tries-- > 0)
        {
            txtinput.Clear();
            MessageBox.Show("Please try again", "Error");
        }
        else
        {
            MessageBox.Show("Sorry, no more tries", "Error");
            Application.Exit();
        }
    }
