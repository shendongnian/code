    public class UserData
    {
        public int UserDataID { get; set; }
        // ... properties ...
    
        public List<UserDataItem> Items { get; set; }
    }
           
    public class UserDataItem
    {
        public int UserDataItemID { get; set; }
        // ... properties ...
    	
    	public UserData OwnerData { get; set; }
    }
    
    var userData = new UserData();
    var userDataItem = new UserDataItem();
    
    // Use navigation property to set the parent.
    userDataItem.OwnerData = userData;
