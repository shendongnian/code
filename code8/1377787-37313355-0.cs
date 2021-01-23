    private void button1_Click(object sender, EventArgs e)
    {
        tb1 = double.Parse(textBox1.Text);
        tb2 = double.Parse(textBox2.Text);
        Reading objR = new Reading(tb1, tb2);
        textBox4.Text= objR.mAdd(tb1,tb2).ToString();
        textBox5.Text = objR.mAdd2().ToString();
    }
    class Reading
    {
        double _tb1, _tb2;
    
        public Reading(string tb1, string tb2)
        {
            this._tb1 = double.Parse(tb1);
            this._tb2 = double.Parse(tb2);
    
        }
        public double mAdd(double a, double b)
        {
            return a + b;
        } 
    
        public double mAdd2()
        {
            return _tb1 + _tb2;
        }
    }
