    public class ThreadViewModel
    {
      public int Id {set;get;}
      public string Title {set;get;}
    }
    public class InboxViewModel
    {
       public List<ThreadViewModel> Threads {set;get;}
       public InboxViewModel()
       {
         Threads= new List<ThreadViewModel>();
       }
    }
