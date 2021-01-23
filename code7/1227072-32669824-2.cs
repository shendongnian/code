    version_check.Click += version_check_Click;  //subscription of the event
    
    public void version_check_Click(object sender, EventArgs e)
    {
        string filepath = @"F:\first_folder\Node3_V_1.3";
        var name = Path.GetFileName(filepath).Split(new[] {'_', 'V'}, StringSplitOptions.RemoveEmptyEntries);
        if (name.Length < 1)
        {
            MessageBox.Show("Failed to update");
            return;
        }    
        MessageBox.Show(string.Format("Upgrading {0} to version {1} ...", name[0], name[1]));
    }
