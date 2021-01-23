    private void Form7_Load(object sender, EventArgs e)
    {
        textBox1.ForeColor = System.Drawing.Color.Gray;   
        textBox1.Text = Properties.Settings.Default.TextBoxDefaultValue;
    }
    private void buttonSave_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default.TextBoxDefaultValue = ret();
        Properties.Settings.Default.Save();
    }
