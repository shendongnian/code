     private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible==true)
            {
                MessageBox.Show("Form is visible");
            }
            else
            {
                MessageBox.Show("Form is hiding");
            }
            
        }
