    private void button1_Click(object sender, EventArgs e)
    {
         string no1 = label1.Text;
         double no1d = Double.Parse( no1 );
         string no2 = label2.Text;
         double no2d = Double.Parse( no2 );
         double result = no1d + no2d;
         label3.Text = result.ToString();
    }
