    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ConditionFulfilled)
        {
            readThatPuppy();
        }
    }
    
    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (ConditionFulfilled)
        {
            readThatPuppy();
        }
    }
    
    private bool ConditionFulfilled()
    {
        return (comboBox1.Text.Equals("Test1") && radioButton1.Checked;
    }
    
    private void  readThatPuppy()
    {
        StreamReader sr = new StreamReader(@"my path");
        string str = sr.ReadToEnd();
        textBox1.Text = str;
    }
