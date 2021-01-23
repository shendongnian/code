    private void button1_Click(object sender, EventArgs e)
    {
         string infile = textBox1.Text;
         string[] lines = System.IO.File.ReadAllLines(infile);
         string temp = "";
         int i = 0;
         foreach (string line in lines)
         {
             string result = Regex.Match(line, @"\d+").Value;
             if (i == 0)
             {
                temp = result;
             }
             else
             {
                temp = temp + "," + result;
             }
             i++;
        }
        richTextBox1.Text = temp;
    }
