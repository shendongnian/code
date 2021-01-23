    public class AddJobToUserVm
    {
      public string UserCode { set;get;}
      //properties for the dropdown 
      public List<SelectListItem> JobsNotAddedYet { set;get;}
      public string SelectedJob { set;get;}
      // The below property is for listing existing jobs already added to the user
      public List<string> JobsOfUser {set;get;}
    }
