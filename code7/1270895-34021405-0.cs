    private void button1_Click(object sender, EventArgs e)
    {
         richTextBox1.AppendText(textBox1.Text);
         System.IO.File.WriteAllText(@"C:\Users\Mohammad_Taghi\Desktop\ab\a.txt", richTextBox1.Text.Replace("\n", Environment.NewLine));            
    }
