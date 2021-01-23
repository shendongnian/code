    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (!checkBox1.Checked) return; //<- this.
        string currPath = textBox1.Text;
        if (!textBox1.Text.Contains("\\"))
        {
            MessageBox.Show("Please define the input folder before starting");
            checkBox1.Checked = false;                
        }
        else if (!textBox2.Text.Contains("\\"))
        {
            MessageBox.Show("Please define the XML Output folder before starting");
            checkBox1.Checked = false;
        }
        else if (!textBox3.Text.Contains("\\"))
        {
            MessageBox.Show("Please define the Converted PPF Output Folder before starting");
            checkBox1.Checked = false;
        }
        else if (!textBox4.Text.Contains("\\"))
        {
            MessageBox.Show("Please define the Invalid PPF Output Folder before starting");
            checkBox1.Checked = false;
        }
        else
        {
            // calls the watcher
            prg.ProgramProcessing(textBox1.Text);
        }
    }
