     public double buysession;
    
        public void button1_Click(object sender, EventArgs e)
        {
            double Value1 = float.Parse(textBox1.Text);
            double divideby = 4;
            double Calcstuff = Value1 / divideby;
            double Rounded1 = Math.Floor(Calcstuff);
            this.buysession = Rounded1 * 4;    // CHANGE HERE
            label1.Text = "you can get " + Rounded1.ToString() +" sets";
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.buysession.ToString());
        }
