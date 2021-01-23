    var model = metadata.Container;
    if (model != null)
    {
        var property = model.GetType().GetProperty(_other, typeof(bool));
    
        if (property != null && (bool)property.GetValue(model))
        {
            MinAge = 0;
        }                
    }
