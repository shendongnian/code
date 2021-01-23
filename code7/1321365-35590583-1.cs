    private void Form1_Load(object sender, EventArgs e)
    {
        checkBox1.CheckedChanged += checkBox_CheckedChanged;
        checkBox2.CheckedChanged += checkBox_CheckedChanged;
        checkBox3.CheckedChanged += checkBox_CheckedChanged;
        checkBox4.CheckedChanged += checkBox_CheckedChanged;
    }
    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        var settings = new Settings();
        settings.downloadonstart = checkBox1.Checked;
        settings.loadonstart = checkBox2.Checked;
        settings.startminimized = checkBox3.Checked;
        settings.displaynotifications = checkBox4.Checked;
        File.WriteAllText(@"c:\configfile.json", JsonConvert.SerializeObject(settings));
    }
 
