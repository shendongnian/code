    public class WdUser : SysDomainModelBase, IWdUser
    {
    //This is your primary key of WDUser
    public int UserID{get;set;}
    //This is for your 1st foreign key mapping
    public virtual WDUser WDUser{get;set;}
    public virtual  ICollection<WDUser> WDUserList{get;set;}
    public int fk1{get;set;}
    //This is for your 2nd foreign key mapping
    public virtual  ICollection<WDUser> WDUserList1{get;set;}
    public int fk2{get;set;}
    }
