    //Start drag for button 2
    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        this.button1.DoDragDrop(this.button1.Text, DragDropEffects.Copy);
    }
    //Start drag for button 3
    private void button3_MouseDown(object sender, MouseEventArgs e)
    {
        this.button3.DoDragDrop(this.button3.Text, DragDropEffects.Copy);
    }
    //Check if drop is allowed and change back color
    private void button2_DragEnter(object sender, DragEventArgs e)
    {
        if(e.Data.GetData(DataFormats.Text).ToString()== button1.Text)
        {
            e.Effect = DragDropEffects.Copy;
            this.button2.BackColor = Color.Green;
        }
        else
        {
            e.Effect = DragDropEffects.None;
            this.button2.BackColor = Color.Red;
        }
    }
    //Perform drop actions
    private void button2_DragDrop(object sender, DragEventArgs e)
    {
        this.button2.Text = e.Data.GetData(DataFormats.Text).ToString();
    }
    //Reset back color here
    private void button2_DragLeave(object sender, EventArgs e)
    {
        this.button2.BackColor = SystemColors.Control;
    }
