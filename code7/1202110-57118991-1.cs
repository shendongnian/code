    private void textBox1_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    if (textBox2.Text == string.Empty)
                    {
                        //textBox2.Text = (0).ToString();
                        label1.Text = ( Convert.ToInt32(textBox1.Text)).ToString();
    
                    }
                    else if (textBox1.Text == string.Empty)
                    {
                        label1.Text = (Convert.ToInt32(textBox2.Text)).ToString();
    
                    }
                    else
                    {
                        label1.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text)).ToString();
    
                    }
                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.Message);
                }
    
            }
    
            private void textBox2_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    if (textBox2.Text == string.Empty)
                    {
                        //textBox2.Text = (0).ToString();
                        label1.Text = (Convert.ToInt32(textBox1.Text)).ToString();
    
                    }
                    else if (textBox1.Text == string.Empty)
                    {
                        label1.Text = (Convert.ToInt32(textBox2.Text)).ToString();
    
                    }
                    else
                    {
                        label1.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text)).ToString();
    
                    }
                }
                catch (Exception e3)
                {
                    MessageBox.Show(e3.Message);
                }
    
            }
