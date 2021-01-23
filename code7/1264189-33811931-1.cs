    private Form1 _parent;
    public Form2(Form1 parent)
    {
      _parent = parent;
    }
    private void button1_Click(object sender, EventArgs e)
    {    
      this.Close(); //Closes Form2(Child)
    }
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        Graphics g = _parent.CreateGraphics();
        g.DrawRectangle(Pens.Black, 100, 100, 50, 50);
    }
