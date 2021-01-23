    private void button1_Click(object sender, EventArgs e)
        {           
            int i = 0;
            textBox1.AppendText("ID: [" + i++ + "] Variable value: [" + g + "]\n");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // int g = 1; // here you declare a local variable
            g = 1;  // use the member variable instead
        }
