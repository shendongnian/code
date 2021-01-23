    foreach (int selected in model.RequestedSelected)
    //foreach (var item in new ArrayList(model.RequestedExercises.RegimeItemID))
    {
        RegimeItem item = model.RequestedExercises[selected];
        if (item != null)
        {
            model.RequestedExercises.Remove(item);
            db.SaveChanges();
        }
    }
