    protected void btnButton1_Click(object sender, EventArgs e)
    {
        double get1;
        double get2;
    
        double answer;
        get1 = Convert.ToDouble(txtGetal1.Text);
        get2 = Convert.ToDouble(txtGetal2.Text);
        answer = (get2==0) ?0 : get1 / get2; // check for 0 and return 0
        txtUitkomst.Text = Convert.ToString(answer);
    }
