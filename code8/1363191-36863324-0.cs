    public bool TryGetMember(GetMemberBinder binder, out object result)
    {
        string name = binder.Name.ToLower();
        if (name == "comment") 
        {
          // save comment
        }
        return false;
    }
