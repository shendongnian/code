    private void button1_Click(object sender, EventArgs e)
    {
        if (rbtnNormalTimer.Checked == true)
        {
            Person(TypeTimer.Unlimited);
        }
        else if(rbtnCountDown.Checked == true)
        {
            Person(TypeTimer.Countdown);
        }
        else if(rbtnLimited.Checked == true)
        {
            Person(TypeTimer.Limited);
        }
    }
