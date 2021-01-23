    var voTable = new object();
    foreach (var ListRoom in getRoom)
    {
      var RoomCount = voISession.QueryOver<SalesAgreementDetail>().Where(w => w.Room == ListRoom.ListID).RowCount();
      voTable = new { category = ListRoom.ListName, value = RoomCount };
    }
    return voTable; 
