    foreach(var item in updateRooms)
    {
    var oldModel= dbContext.Rooms.First(a => a.Id == item.Id);
     if(oldModel !=null)
    {
        oldModel.Name = item.Name;
        oldModel.Address = item.Address;
        dbContext.SaveChanges();
    } 
