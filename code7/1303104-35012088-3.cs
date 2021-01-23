    List<dynamic> Ts = ((IEnumerable<T>) db.GetType().GetProperty(typeof(T).Name).GetValue(db, null)).ToList(); //.Select(ii => new ImproItemViewModel( (T)ii));
    foreach(dynamic t in Ts)
    {
        ImproItems.Add(new ImproItemViewModel(t));
    }
    
