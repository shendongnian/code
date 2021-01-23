     public void LoadWorking()
                { 
                    List<string> workingHoursList = new List<string>();
                    workingHoursList.Add("08:00:00");
                    workingHoursList.Add("09:00:00");
                    workingHoursList.Add("10:00:00");
                    workingHoursList.Add("11:00:00");
                    workingHoursList.Add("12:00:00");
                    workingHoursList.Add("13:00:00");
                    workingHoursList.Add("14:00:00");
                    workingHoursList.Add("15:00:00");
                    foreach (string s in workingHoursList)
                        listBox1.Items.Add(s);
                }
          private void buttonChanged_Click(object sender, EventArgs e)
                {
                    if (listBox1.SelectedItem != null)
                    {
                        string h = "", m = "", s = "";
                        if (textBox_Hour.Text == "") h = "00"; else h = textBox_Hour.Text;
                        if (textBox_Minute.Text == "") m = "00"; else m = textBox_Minute.Text;
                        if (textBox_Second.Text == "") s = "00"; else s = textBox_Second.Text;
        
                        listBox1.Items[listBox1.SelectedIndex] = 
                            textBox_Hour.Text + ":" + textBox_Minute.Text+":" + textBox_Second.Text;
        
                    }
                    else 
                    {
                        
                    }
    
     
            }
    //reading
       private void buttonRead_Click(object sender, EventArgs e)
            {
                if (listBox1.SelectedItem != null) {
                    string selectedTime = listBox1.SelectedItem.ToString(); 
                    string []split = selectedTime.Split(':');
    
                    int i = 0;
                    foreach (string sp in split) 
                    {
                        if (i == 0) { labelRead.Text = "Hour: " + sp + "\n"; }
                        else if (i == 1) { labelRead.Text += "Minute: " + sp + "\n"; }
                        else if (i == 2) { labelRead.Text += "Second: " + sp + "\n"; }
                        i++;
                    }
    
                }
            }
