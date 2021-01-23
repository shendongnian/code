    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        //Save User Input
    	string[] itemsToStore = new string[comboBox.Items.Count];
    	
    	for (int i = 0; i < comboBox.Items.Count; i++)
        {
            itemsToStore[i] = comboBox.GetItemText(comboBox.Items[i]); 
        }
    	
        MySettings.Default["SaveSaveLocationText"] = saveLocationTextBox.Text;
    	MySettings.Default["SaveSaveLocationItems"] = string.Join(",", itemsToStore);
        MySettings.Default.Save();
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        //Load Settings
        saveLocationTextBox.Text = MySettings.Default["SaveSaveLocationText"].ToString();
    
    	string listItems = MySettings.Default["SaveSaveLocationItems"].ToString();
    	
        List<string> list = new List<string>();
        list.AddRange(listItems.Split(','));
    
        comboBox.DataSource = list;
    }
