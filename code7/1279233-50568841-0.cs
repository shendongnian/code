        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Update";
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
           
            Thread.Sleep(5000);
       
            button1.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
