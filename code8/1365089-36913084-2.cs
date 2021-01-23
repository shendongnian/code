    Person person;
    if (rbtnNormalTimer.Checked == true)
    {
        person = Person(TypeTimer.Unlimited);
    }
    else if(rbtnCountDown.Checked == true)
    {
        person = Person(TypeTimer.Countdown);
    }
    else if(rbtnLimited.Checked == true)
    {
        person = Person(TypeTimer.Limited);
    }
