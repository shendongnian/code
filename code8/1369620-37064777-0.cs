    private void button1_Click(object sender, EventArgs e)
    {
                string infile = textBox1.Text;
                StreamReader sr = new StreamReader(infile);
                string allDetails = File.ReadAllText(infile);
                string result = string.Empty;
                foreach (var item in Regex.Matches(allDetails, @"\d+"))
                {
                    result = result + item.ToString() + ",";
                }
    
                richTextBox1.Text = result.TrimEnd(',');
    }
