    IDataServiceQueryable<DUTFullView> query = from DUTFullViewIDpass in this.DataWorkspace.AUTOData.DUTFullViews
                    where (DUTFullViewIDpass.DUTTypeID == v.DUTTypeID)
                    && (DUTFullViewIDpass.SN == v.SN)
                    select DUTFullViewIDpass;
    
    if(!query.Any())
        return;
        
    foreach(var item in query)
    {
        // You could do your logic here
        //var example = item.Property1
    }
