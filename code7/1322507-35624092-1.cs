    public void SetGroupId(Group group){
       if (groupid.HasValue)
       {
           row.GroupId = group.Value;
       }
       else
       {
           row.SetGroupIdNull();
       }
    } 
