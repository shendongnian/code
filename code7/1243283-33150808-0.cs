    private void PopulateDrives()
    {
        try
        {
            combobox.items.clear()
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {   
                    string dl = d.VolumeLabel;
                    string dt = Convert.ToString(d.DriveType); 
                    if (!comboBox1.Items.Contains(d.Name))
                    {
                        comboBox1.Items.Add(d.Name.Remove(2));
                    }  
                }
                comboBox1.SelectedIndex = 0;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        catch { MessageBox.Show("Error retrieving Drive Information", "Error!"); }
    }
    
