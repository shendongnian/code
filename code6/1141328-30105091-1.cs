    foreach(int i in RequestedSelected)
    {
       RegimeItem item = model.RequestedExercises.FirstOrDefault(i => i.RegimeItemID == i);
       if(item != null)
       {
          User user = db.Users.Find(id);
          user.RegimeItems.Remove(item);
       }
    }
