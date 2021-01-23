    Player player;
    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            player = new Player();
            player.Name = textBox1.Text; //Problematic line
        }
        private void Button_Start_Click(object sender, EventArgs e)
        {
            switch (player.Name.ToUpper())
            {
                case "N/A": 
                   Label_Question.Text = "Please set your name!"; 
                   return;
                default: 
                   Label_Question.Hide(); 
                   break;
            }
        }
