    private void button1_Click(object sender, EventArgs e)
    {
         string infile = textBox1.Text;
         string[] lines = System.IO.File.ReadAllLines(infile);
         foreach (string line in lines)
         {
             string result = Regex.Match(line, @"\d+").Value;
             richTextBox1.Text = result ;
         }
    }
