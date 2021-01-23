    Person person;
    if (rbtnNormalTimer.Checked == true)
    {
        person = new Person(TypeTimer.Unlimited);
    }
    else if(rbtnCountDown.Checked == true)
    {
        person = new Person(TypeTimer.Countdown);
    }
    else if(rbtnLimited.Checked == true)
    {
        person = new Person(TypeTimer.Limited);
    }
