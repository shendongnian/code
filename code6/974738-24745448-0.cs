    private void Form2_Load(object sender, EventArgs e)
    {
        pumpPort = SerialPort.GetPortNames();
        this.comboBox1.Items.AddRange(pumpPort);
    }
    public void comboBox1_SelectedIndexChanged(object sender, EventArgs eventArgs)
    {
        Properties.Settings.Default.Setting = this.comboBox1.SelectedItem;
        Properties.Settings.Default.Save();
    }
