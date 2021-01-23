    public OptionsMenuForm()
    {
        InitializeComponent();
        //Read the settings from a file with comma delimited 1's and 0's or whatever you like
        string[] values = System.IO.File.ReadAllText("c:\temp\a.txt").Split(',');
        checkBox1.Checked = Convert.ToBoolean(values[0]);
        checkBox2.Checked = Convert.ToBoolean(values[1]);
    
        //On checkbox changes save the settings
        checkBox1.CheckedChanged +=SaveSettings;
        checkBox2.CheckedChanged +=SaveSettings;
    }
    
    public void SaveSettings(object sender,EventArgs e)
    {
        StringBuilder sbValues = new StringBuilder();
        int i = 0;
    
        i = checkBox1.Checked ? 1 : 0;
        sbValues.Append(i.ToString() + ",");
    
        i = checkBox2.Checked ? 1 : 0;
        sbValues.Append(i.ToString() + ",");
    
        System.IO.File.WriteAllText("c:\temp\a.txt",sbValues.ToString());
    }
