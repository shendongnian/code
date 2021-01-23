    public ArrayList BirthdaysThisWeek()
    {
        ArrayList members = new ArrayList();
    
        DateTime today = DateTime.Today;
        int delta = DayOfWeek.Monday - today.DayOfWeek;
        DateTime monday = today.AddDays(delta);
        DateTime sunday = monday.AddDays(6);
    
        foreach (Member member in allMembers)
        {
            DateTime dob = member.DateOfBirth.Date;
    
            //Check to see if a member's birthdate is between Monday and Sunday
            if (IsBirthDayInRange(dob, monday, sunday)
            {
                //Add member to members ArrayList
                members.Add(member);
            }
        }
        return members;
    }
