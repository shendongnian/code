    EntityRecommendation time;
    EntityRecommendation date;
    
    var timeFound = result.TryFindEntity(EntityConstant.EntityBuiltInTime, out time);
    if (result.TryFindEntity(EntityConstant.EntityBuiltInDate, out date))
    {
        return timeFound ? (date.Entity + " " + time.Entity).Parse() : date.Entity.Parse();
    }
