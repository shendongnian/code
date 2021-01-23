    public void WhateverYourMethodIs()
    {
        switch (name)
        {
            case "name 1":
                bday = DateTime.Parse("11.11.1988");
                break;
            case "name 2":
                bday = DateTime.Parse("11.12.1988");
                break;
            case "name 3":
                bday = DateTime.Parse("03.12.1987");  
                break;
        }   
        if (this.IsBirthday(bday))
        {
            // do whatever you want for when it's the name's birthday.
        }
    }
    public bool IsBirthday(DateTime bday)
    {
        if (bday.Day == DateTime.Now.Day && bday.Month == DateTime.Now.Month)
            return true;
        return false;
    }
