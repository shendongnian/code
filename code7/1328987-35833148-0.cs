    int val1, val2, val3, val4, val5;
    public void xylosTextBox2_TextChanged(object sender, EventArgs e)
    {
        //---------------------------------------------------------------------------
        val1 = Convert.ToInt32(xylosTextBox1.Text);
        val2 = Convert.ToInt32(xylosTextBox2.Text);
        val3 = val2 * val1 / 100;
        val5 = val1 + val2;
        int t1 = Convert.ToInt32(xylosTextBox1.Text);
        int t2 = Convert.ToInt32(xylosTextBox2.Text);
        int t3 = val5; 
        //-----------------------------------------------------------------------------
        if (val5 > 1)
        {
            xylosTextBox3.Text = val3.ToString();
        }
    }
