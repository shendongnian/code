    var myObject = _Context.CurrentTransformers.Where(a => a.ID.ToString().Contains(search) ||
                                                                   a.ADMSKey != null && a.ADMSKey.ToLower().Contains(search.ToLower()) ||
                                                                   a.AccuracyClass != null && a.AccuracyClass.ToString().ToLower().Contains(search.ToLower()) ||
                                                                   a.CoreCount != null && a.CoreCount.ToLower().Contains(search.ToLower()) ||
                                                                   a.PrimaryCurrentRatio != null && a.PrimaryCurrentRatio.ToLower().Contains(search.ToLower()) ||
                                                                   a.SecondaryCurrentRatio != null && a.SecondaryCurrentRatio.ToLower().Contains(search.ToLower()) ||
                                                                   a.EOLXINIVVC != null && a.EOLXINIVVC.ToLower().Contains(search.ToLower()));
