    public class IndexViewModel
    {
	  public List<User> FoundUsers {get; set;}
	
      public string Name {get; set;}
      public IndexViewModel(List<User> found)
      {
		this.FoundUsers = found;
	  }
    }
	
