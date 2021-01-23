    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
                string[] merged;
                string[] lines = { "1", "2", "3" };
                string[] linesTwo = { "2.1", "2.2", "2.3" };
                if(CheckBox1.Checked)
                {
                    merged = lines.Concat(linesTwo).ToArray();
                }
    
    }
