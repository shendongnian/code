        Member newMember = new Member();
        newMember.Email = userKey;//email of the user that you want to add
        newMember.Role = "MEMBER";
        newMember.Type = "USER";
        newMember.Kind = "admin#directory#member";
        
        ser.Members.Insert(newMember, "MyDestinationGroup@mydomain").Execute();
        
