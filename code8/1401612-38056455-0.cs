    using System.Security.Principal;          
    
    using (new Impersonator("myUsername", "myDomainname", "myPassword"))
              {
                 return File(@"<<REMOTE_SERVER>>\<<Folder>>\Test.csv", "application/csv", "test.csv");
              }
