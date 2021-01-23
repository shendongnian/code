    public IList<Report> GetReport(CmsEntities context, long manufacturerId, long? regionId, long? vehicleTypeId, int pageSize, int currentPage)
            {
                
            //Code removed to simplify
        
            return  query2.Skip(pageSize * currentPage).Take(pageSize );
            
            }
