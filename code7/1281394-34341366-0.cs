    public override bool Equals(object obj)
    {    
        User other = obj as User;
        if( other == null ) return false;
        return other.Name == Name && other.IdNumber == IdNumber && other.OrgName == OrgName && other.AcctCode == AcctCode;
    }
    
    public override int GetHashCode()
    {
        return IdNumber.GetHashCode();
    }
