    foreach(int selected in RequestedSelected)
    {
       RegimeItem item = model.RequestedExercises.FirstOrDefault(i => i.RegimeItemID == selected);
       if(item != null)
       {
          User user = db.Users.Find(id);
          user.RegimeItems.Remove(item);
       }
    }
