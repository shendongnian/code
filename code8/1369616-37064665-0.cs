    private void button1_Click(object sender, EventArgs e)
    {
       string allDetails = File.ReadAllText(textBox1.Text);
       foreach(string word in allDetails.Split(' '))
       {
           int number;
           if(int.TryParse(word, out number))
               richTextBox1.Text = richTextBox1.Text + "," + number ;
       }
    }
