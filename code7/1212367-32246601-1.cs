    bool validTelephone = AllOrNothingEquals(Member.Telephone, telephone);
    bool validName = AllOrNothingEquals(Member.Name, name);
    bool validEmail = AllOrNothingEquals(Member.Email, email);
    
    if(validTelephone && validEmail && validName)
    {
        //Is it valid
    }
    else
    {
        //NotReally
    }
