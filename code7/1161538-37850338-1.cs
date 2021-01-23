    private void radioButton1_CheckedChanged(object sender, EventArgs e)
            {
                if (radioButton1.Checked == true)
                {
                   UpdatePanel1.Visible = true;
                   PriceLabel.Text = " Sale Price:";
                   
                }
                else
                {
                   UpdatePanel1.Visible = true;
                   PriceLabel.Text = " Rent Price:";
                }
            }
