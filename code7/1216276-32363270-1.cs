        User newUser = new User();
        UserName newUserName = new UserName();
        newUser.PrimaryEmail = Email.Text;
        newUserName.GivenName = FirstName_txt.Text;
        newUserName.FamilyName = LastName_txt.Text;
        newUser.Name = newUserName;
        newUser.Password = password;
        **newUser.OrgUnitPath ="\My\Organization\Unit\path\";**
        User results = ser.Users.Insert(newUser).Execute();
        
