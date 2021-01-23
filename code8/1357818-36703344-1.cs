    var index = Enumerable.Range(0, Math.Min(models.Count, views.Count))
                          .First(i => !Model.Equals(models[i], views[i].Model));
    //If models.Count > views.Count
    var addedModel = models[index];
    //If views.Count > models.Count
    var viewToRemove = views[index];
 
