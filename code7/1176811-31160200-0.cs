            int count = 0;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                string value = comboBox1.GetItemText(comboBox1.Items[i]);
                if (value.Contains(comboBox1.Text))
                {
                    count++;
                    break;
                }
            }
            if (count > 0)
            {
                //do something
            }
            else
            {
                MessageBox.Show("The comboBox1 contains new value");
            }
 
