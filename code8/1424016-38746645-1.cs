    private void button1_Click(object sender, EventArgs e)
    {
          if (comboBox1.SelectedIndex == 0)
                {
    
    
                    for (int i = 0; i <= 10; i++)
                    {
                        string item = i + "A"; // Given"A" to seperate from each other
                        comboBox2.Items.Add(item);
                        vals.Add(new KeyValuePair<int, string>(0, item)); // CatA has 0 key value
    
                    }
    
                    MessageBox.Show("Serial Book Generated Success", "Success");
                }
    
                if (comboBox1.SelectedIndex == 1)
                {
    
    
                    for (int i = 0; i <= 5; i++)
                    {
                        string item = i + "B"; // Given "B" to seperate from each other
                        comboBox2.Items.Add(item);
                        vals.Add(new KeyValuePair<int, string>(1, item)); // CatB has 1 key value
                    }
    
                    MessageBox.Show("Serial Book Generated Success", "Success");
    
                }
     }
