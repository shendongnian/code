    private void button1_Click (object sender, EventArgs e)
    {
    
        string [] individualDirs = input.Text.Split(',');
     
        foreach (string one_dir in individualDirs)
        { 
    
            string[] dirs = Directory.GetDirectories(@"D:\", one_dir + "*", SearchOption.AllDirectories);
    
            foreach (string dir in dirs)
            {   // to add more Text to your TextBox use +=
                Path.Text += dir.ToString() + Environment.NewLine;
            }
        }
    }
