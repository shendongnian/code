    private void CmdProgBar_Click(object sender, EventArgs e) //After the buyer has used up all their credits they shouldn't be able to purchase anymore
    {
        int Credits = Convert.ToInt32(lblcredits.Text);
        int cost = comboBox1.SelectedIndex + 1; //Assuming cost is equal to selected index plus 1
 
        if( Credits >= cost)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("You've selected Pear"); //Correct term from PAIR to PEAR
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("You've selected Banana");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                MessageBox.Show("You've selected Apple");
            }
            Credits -= cost;
            lblcredits.Text = Convert.ToString(Credits); //Move down because this will always be used after a selection occurs
        } //if
        else
        {
            MessageBox.Show("You do not have enough credits");    
        }//End else
    }
