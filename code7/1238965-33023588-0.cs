    public bool UpdateEffectiveDate(db aEntity, int driverId, DateTime effectiveDate, string UserId)
    {
        //db myentity = new myentity();
        Driver driver = aEntity.Drivers.Find(driverId);
        driver.EffectiveDate = effectiveDate;
        driver.LastModifiedBy = UserId;
        driver.LastModifiedDate = DateTime.Now;
        aEntity.Drivers.Attach(driver);
        aEntity.Entry(driver).Property(x => x.EffectiveDate).IsModified = true;
        aEntity.Entry(driver).Property(x => x.LastModifiedBy).IsModified = true;
        aEntity.Entry(driver).Property(x => x.LastModifiedDate).IsModified = true;
        return (aEntity.SaveChanges() > 0);
    }
    
