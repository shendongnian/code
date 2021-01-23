    public double buysession;
    double Value1;
    double divideby;
    double Calcstuff;
    double Rounded1;
    double buysession;
    public void button1_Click(object sender, EventArgs e)
    {
        Value1 = float.Parse(textBox1.Text);
        divideby = 4;
        Calcstuff = Value1 / divideby;
        Rounded1 = Math.Floor(Calcstuff);
        double buysession = Rounded1 * 4;
        {
            label1.Text = "you can get " + Rounded1.ToString() +" sets";
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        MessageBox.Show(buysession.ToString());
    }
