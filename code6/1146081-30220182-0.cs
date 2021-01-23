    try{
            CaseEntities caseEntities = new CaseEntities();
            // Get an existing Entity (this line works)
            var entity = caseEntities.RecordsDistributionPreferences.Find("0001");
            // Change a field
            entity.ModifiedBy = "duncan";
    
            // get row version before save
            byte[] rowVersionBefore = entity.RowVersion;
    
            // Save Changes (this next line throws null reference exeption)
            caseEntities.SaveChanges();
    
            // get row version after save
            byte[] rowVersionAfter = entity.RowVersion;
    
            // Check that row version are different
            Assert.AreNotEqual(BitConverter.ToInt64(rowVersionBefore.Reverse().ToArray(), 0), BitConverter.ToInt64(rowVersionAfter.Reverse().ToArray(), 0));
        }
    catch (NullReferenceException ex){
    
    }
