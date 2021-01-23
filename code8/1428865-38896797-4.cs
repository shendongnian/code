    public string Value { get; set; }
    private void btn1_Click(object sender, EventArgs e)
    {
        this.Value = textBox1.Text; //pass the TextBox value to the property
        this.DialogResult = DialogResult.OK; // Cancel would mean you closed/canceled the 
                                             // form without pressing OK-Button (btn1)
        this.Close();
    }
