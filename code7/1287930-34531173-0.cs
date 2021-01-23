    private void button1_Click(object sender, EventArgs e)
    {
    this.BackColor = Color.White;
    foreach(Control l in Controls)
    {
        if(l.GetType()==typeof(System.Windows.Forms.Label))
        {
            l.ForeColor = Color.Black;
        }           
    }
    }
