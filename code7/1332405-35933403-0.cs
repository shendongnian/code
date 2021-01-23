    public class WdUser : SysDomainModelBase, IWdUser
    {
    //This is your primary key of WDUser
    public int UserID{get;set;}
    //This is for your foreign key mapping
    public WDUser WDUser{get;set;}
    public ICollection<WDUser> WDUserList{get;set;}
    }
