    private int clickcount { get; set; } 
    private void buttonOne_Click(object sender, EventArgs e)
    {   
        if(++clickcount == 10)
           MessageBox.Show("Your message")
    }
