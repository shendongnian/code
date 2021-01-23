    public void SaveFilesDetails(DataTable dt)
    {
         
         List<Location> list = new List<Location>();
         foreach (DataRow row in dt.Rows)
         {
             Location loc = new Location();
             loc.Postcode = row["Postcode"].ToString();
             loc.Latitude = row["Latitude"].ToString();
             loc.Longitude = row["Longitude"].ToString();
             loc.County = row["County"].ToString();
             loc.District = row["District"].ToString();
             loc.Ward = row["Ward"].ToString();
             loc.CountryRegion = row["CountryRegion"].ToString();
             list.Add(loc);
         }
    
         using (PostCodesEntities dataContext = new PostCodesEntities())
         {                
             dataContext.Locations.AddRange(list);                
             dataContext.SaveChanges();
         }
        }
