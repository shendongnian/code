    AutoCompleteStringCollection source = textBox1.AutoCompleteCustomSource;
    
    if (Properties.Settings.Default.IPLIST != null)
    {
        Properties.Settings.Default.IPLIST.Clear();
        Properties.Settings.Default.IPLIST.AddRange(source.Cast<string>().ToArray());
        Properties.Settings.Default.Save();
    }
