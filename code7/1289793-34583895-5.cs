    private void Left_btn_Click(object sender, EventArgs e) //The name is Left
    {
        if (panel1.Location.X < 720) 
        {
            panel1.Location = new Point(panel1.Location.X - 55 , panel1.Location.Y);             
        }
    }
    private void Right_btn_Click(object sender, EventArgs e) //The name is Right
    {
        if (panel1.Location.X < 720) 
        {
            panel1.Location = new Point(panel1.Location.X + 55, panel1.Location.Y);
        }
    }
