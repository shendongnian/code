    private void button1_Click(object sender, EventArgs e)
    {
       string infile = textBox1.Text;
       StreamReader sr = new StreamReader(infile);
       string allDetails = File.ReadAllText(infile);
       var regexMatchCollection = Regex.Matches(allDetails, @"\d+");
       foreach(MatchCollection mc in regexMatchCollection)
       { 
         richTextBox1.AppendText(mc.Value);
       }
    }
