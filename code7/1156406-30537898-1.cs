        //read from here
        private void Form1_Load(object sender, EventArgs e)
        {
            //changes whatever you type into your textbox to be an asterisk 
            textBox1.PasswordChar = '*'; 
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              //ignore this method
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Just to validate that the text is what you want it to be
            string text = textBox1.Text;
            MessageBox.Show(text);
        }
