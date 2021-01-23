    private Dictionary<int,DateTime> ActiveUsers
    {
        get 
        { 
          if(Cache["ActiveUsers"] == null)
            Cache["ActiveUsers"] = new Dictionary<int,DateTime>();
    	  return Cache["ActiveUsers"];
        } 
        set { Cache["ActiveUsers"] = value; }
    }
    private void KeepTrackActiveUsers()
    {
        ActiveUsers[CurrentUserId] = DateTime.Now;
    }   
 
    private const int expirationTime = 600;   
    private IEnumerable<int> GetActiveUsers()
    {		
    	DateTime now = DateTime.Now;
    	ActiveUsers = ActiveUsers
    		.Where(x => now.Subtract(x.Value).TotalSeconds < expirationTime)
    		.ToDictionary(x => x.Key, x => x.Value);
        return ActiveUsers.Keys;
    }
        
    private void SetInactiveUser()
    {
        ActiveUsers.Remove(CurrentUserId);
    }
    //to be defined
    private int CurrentUserId
    {
    	get { return default(int); }
    }
