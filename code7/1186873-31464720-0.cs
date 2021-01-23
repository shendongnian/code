    public void UpdateCoLocation(tblCoLocation obj) {
        var upd = dat.tblCoLocations.FirstOrDefault(itm => itm.LocID == obj.LocID);
    
        if (upd != null) {
            upd.ModOn = obj.ModOn < System.Data.SqlTypes.SqlDateTime.MinValue ? 
                System.Data.SqlTypes.SqlDateTime.MinValue : 
                obj.ModOn;
            upd.ModBy = obj.ModBy;
        }
    
        dat.SaveChanges();
    }
 
