    if(Settings.Length > 0)
    {
        int count = 0;
        foreach (string s in Settings.Default.Name)
        {
            count++;
        }
        Settings.Default.Name[count] = tb_add_name.Text;
        Settings.Default.Save();
    }
