    public class Contact
    {
      public string Firstname {get; set;}
      public string Lastname{get; set;}
      public string Email {get; set;}
      public string Display {get; set;}
    }
        var query = from o in Globals.DB.Friends
                    where o.UserEmail == Properties.Settings.Default.Email
                    select new Contact
                    {
                        FirstName = o.FirstName,
                        LastName = o.LastName,
                        Email = o.Email,
                        Display = string.Format(" {0} {1} - ({2})", o.FirstName, o.LastName, o.Email),
                    };
