    private void button1_Click(object sender, EventArgs e)
    {
        if(your condition here)
        {
            //Make transparent and click pass through
            this.BackColor = Color.Magenta; 
        }
        else
        {
            //Make it normal
            this.BackColor = SystemColors.Control;
        }
    }
