    if (!mylist.Select(l => l.ID).Contains(mynewid)) {
       var item = new Notifcation();
       item.ID = mynewid;
       item..... // fill the rest
       
       mylist.Add(item);
    }
