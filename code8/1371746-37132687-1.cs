    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)//checkbox name CheckBox_1
    {
                string[] merged;
                string[] lines = { "1", "2", "3" };
                string[] linesTwo = { "2.1", "2.2", "2.3" };
                if(CheckBox1.Checked) // check is checkbox checked
                {
                    merged = lines.Concat(linesTwo).ToArray(); // merge
                }
    
    }
