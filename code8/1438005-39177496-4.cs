     public void DoStuff(){
             using (var db = new dbContext()){
                 DoThings(db);
                 db.SaveChanges();
             }
          }
        
        public void DoThings(DbContext db){
            if (db =null){
               using (var db = new dbContext()){
                  DoInternalThings(db);
                 }
               }else{
                  DoInternalThings(db);
               }       
          }
