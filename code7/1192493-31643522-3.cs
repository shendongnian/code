	public void listbox()
    {
        LOADMOD.Items.Clear();
        string[] getfiles = Directory.GetFiles(Properties.Settings.Default.rawpath + "\\mods");
        string[] dirs = Directory.GetDirectories(Properties.Settings.Default.rawpath + "\\mods");
        LOADMOD.DisplayMember = "Name";
        LOADMOD.ValueMember = "Path";
        foreach(string file in getfiles)
        {
            // Create an item for the list
            var thisItem = new MyType {
                Name = path.getfilename(file),
                Path = file
                }; 
            LOADMOD.Items.Add(thisItem);
        }
        foreach (string dir in dirs)
        {
            // Create an item for the list
            var thisItem = new MyType {
                Name = path.getfilename(dir),
                Path = dir
                }; 
            LOADMOD.Items.Add(thisItem);
        }
    }
