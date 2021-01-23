    public class UserWithEventsVm
    {
      public string DisplayName {set;get;}
      public List<EventVm> Events {set;get;}
      //Add other properties as needed by the view
    
      public UserWithEventsVm()
      {
        Events=new List<EventVm>();
      }
    }
    public class EventVm
    {
      public int Id {set;get;}
      public string EventTitle {set;get;} 
    }
