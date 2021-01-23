    public string Value { get; set; }
    private void btn1_Click(object sender, EventArgs e)
    {
        Form1.new_item = textBox1.Text;
        this.DialogResult = DialogResult.OK; // Cancel would mean you closed/canceled the 
                                             // form without pressing OK-Button (btn1)
        this.Close();
    }
