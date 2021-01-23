        Random rand = new Random();
    protected void Generate_Click(object sender, EventArgs e)
        {
            TextBox1.Text = GenerateNumber().ToString();
            TextBox2.Text = GenerateNumber().ToString();
            TextBox3.Text = GenerateNumber().ToString();
            TextBox4.Text = GenerateNumber().ToString();
        }
    
        private int GenerateNumber()
        {
            int i = 0;
            i = rand.Next(0, 100);
            return i;
        }
