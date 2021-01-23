    private void ProcessClient() {
    {
       using (MyDBEntities db = new MyDBEntities())
       {
    
	     [...] doing client stuff [...]
    
	     aClient.LastUpdated = DateTime.Now;
    
	     db.AddOrUpdate(db, db.Clients, aClient, aClient.ClientID);
         db.SaveChanges();
         ClientId = aClient.ClientID;   // now I can use this to form FKs
       }
    }
