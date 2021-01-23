    using (var db = new YourContext()) 
    { 
        var moneyRow = db.UserMoney.Find(loggedinUserID);
        moneyRow.MONEY -= moneyToSpend; 
     
        bool saveFailed; 
        do 
        { 
            saveFailed = false; 
            try 
            { 
                db.SaveChanges(); 
            } 
            catch (DbUpdateConcurrencyException ex) 
            { 
                saveFailed = true; 
     
                // Update original values from the database 
                var entry = ex.Entries.Single(); 
                entry.OriginalValues.SetValues(entry.GetDatabaseValues()); 
            } 
     
        } while (saveFailed); 
    }
