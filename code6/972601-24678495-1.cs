    public ViewResult Whatever() {
    	var brand = GetBrand(brandName);
        var brandSnapshots = GetBrandSnapshots();
    
        return View(brand, brandSnapshots);
    }
    private Brand GetBrand(string brandName)
    {
        try 
        {
            var brand = new Brand();
            brand.Name = brandName;
            // database stuffs ...
            return brand;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private List<Snapshot> GetBrandSnapshots()
    {
        // ...
        // DB stuffs -- that *really* should not be in the controller anyways.
        // ...
        var snapshots = new List<BrandEmailList>();
    	while (dbResult.Read())
    	{
            // object initializer syntax
            snapshots.Add(new Snapshot {
               	ID = Convert.ToInt32(dbResult["snapshot_id"]),
    		Guid = dbResult["snapshot_guid"].ToString(),
    		DateTimeSent = dbResult["date_sent"],
    		Subject = dbResult["subject"].ToString(),
    		Image = dbResult["image"],
            });    	
    	}
        return snapshots
    }
