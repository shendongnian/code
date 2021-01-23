        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(Properties.Settings.Default.Customer[0]);
            listBox1.Items.Add(Properties.Settings.Default.Customer[1]);
            listBox1.Items.Add(Properties.Settings.Default.Customer[2]);
            //I recommend using a loop to add these
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.SelectedIndex == i)
                {
                    if (Properties.Settings.Default.Extension[i].Contains("log"))
                    {
                        comboBox1.SelectedIndex = 0; //Log 
                    }
                    else if (Properties.Settings.Default.Extension[i].Contains("txt"))
                    {
                        comboBox1.SelectedIndex = 1; //Txt
                    }
                    txtDateFormat.Text = Properties.Settings.Default.DateFormat[i];
                }
            }
        }
