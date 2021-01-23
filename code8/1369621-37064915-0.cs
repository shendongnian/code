     private void button1_Click(object sender, EventArgs e)
     {          
        string filedetails = File.ReadAllText(textBox1.Text);
        var regexCollection = Regex.Matches(filedetails, @"\d+");
        foreach (Match rc in regexCollection)
           richTextBox1.AppendText(rc.Value + ",");
     }
