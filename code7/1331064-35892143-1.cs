        ......
        if (RadioButton1.Checked == true)
        {
            Total = Total + 1;
        }
        else if (radio2.Checked == true)
        {
            Total = 0;
        }
        CountTest.Text = Convert.ToString(Total);   <----- this
