    public class Emails : ObservableCollection<Email>
    {
       public Emails()
       {
       }
        
       public Emails(IEnumerable<Email> emails)
       {
          foreach (var e in emails)
          {
            if(IsValidEmail(e.Address)
            {
              Add(e);
            }
          }
       }
        
      public IEnumerable<Email> GetAll()
      {
         return Items;
      }    
    }
