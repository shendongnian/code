    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBox1.SelectedIndex == 0)
                {
    
                    comboBox2.Items.Clear();
                    foreach (var item in vals)
                    {
                        if (item.Key == 0) //If Key value is 0, if it is CategoryA
                        {
                            comboBox2.Items.Add(item.Value);
                           // MessageBox.Show("Adding: " + (item.Value.ToString()));
                            comboBox2.Refresh();
                        }
                    }
    
                }
    
                if (comboBox1.SelectedIndex == 1)
                {
    
                    comboBox2.Items.Clear();
                    foreach (var item in vals)
                    {
                        if (item.Key == 1)    //If Key value is 1, if it is CategoryB
                        {
                         
                            comboBox2.Items.Add(item.Value);
                            //MessageBox.Show("Adding: " + (item.Value.ToString()));
                            comboBox2.Refresh();
                        }
                    }
                }
    
    
            }
