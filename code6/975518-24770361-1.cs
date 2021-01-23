    private void textBox5_TextChanged(object sender, EventArgs e)
    {
       bool allGood = false;
        foreach (Control control in Controls )
        {
            if (control is TextBox)
            {
                string test = ((TextBox)control).Text;
                if (test.Length > 0)
                {
                    allGood = true;
                }
                else
                {
                    MessageBox.Show("Fill all textbox first");
                    break;
                }
            }
        }
        btnEnter.Enabled = allGood; 
    }
