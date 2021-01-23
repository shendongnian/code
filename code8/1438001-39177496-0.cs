    public void DoStuff(){
         using (var db = new dbContext()){
             DoThings(db);
             db.SaveChanges();
         }
      }
    
    public void DoThings(DbContext db){
                  DoInternalThings(db);
         }
