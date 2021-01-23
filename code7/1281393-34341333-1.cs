    public override bool Equals(object obj)
    {    
        
        if(!(obj is User)) 
        {
            return false;
        }
        
         User user= obj as User;
        return user.Name == Name && user.IdNumber == IdNumber && user.OrgName == OrgName && user.AcctCode == AcctCode;
    }
    
    public override int GetHashCode()
    {
        return IdNumber.GetHashCode();
    }
