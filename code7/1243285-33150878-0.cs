    private void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            comboBox1.Items.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
    
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady)
                {   
                    string dl = d.VolumeLabel;
                    string dt = Convert.ToString(d.DriveType); 
                    comboBox1.Items.Add(d.Name.Remove(2));
                }
            }
                comboBox1.SelectedIndex = 0;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        catch { MessageBox.Show("Error retrieving Drive Information", "Error!"); }
    }
