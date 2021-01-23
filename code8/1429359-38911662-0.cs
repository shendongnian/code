    public YourForm()
    {
        radioButton1.Tag = groupBox1;
        radioButton2.Tag = groupBox2;
        radioButton3.Tag = groupBox3;
        radioButton1.CheckedChanged += radioButtons_CheckedChanged;
        radioButton2.CheckedChanged += radioButtons_CheckedChanged;
        radioButton3.CheckedChanged += radioButtons_CheckedChanged;
    }
    void radioButtons_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton button = sender as RadioButton;
        if (button == null) return;
        GroupBox box = button .Tag as GroupBox
        if (box == null) return;
        
        box.Enabled = button.Checked;
    }
