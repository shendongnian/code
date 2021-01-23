    var voTable = new List<object>();   //changes here
    foreach (var ListRoom in getRoom)
    {
      var RoomCount = voISession.QueryOver<SalesAgreementDetail>().Where(w => w.Room == ListRoom.ListID).RowCount();
      voTable.Add(new { category = ListRoom.ListName, value = RoomCount }); //changes here
    }
    return voTable; 
