    var PropList = P
      .GetType()
      .GetProperty("Properties")
      .GetValue(this, null) as IEnumerable<PropertyInfo>; // notice "as ..."
    // Since PropList is IEnumerable<T> you can loop over it
    foreach (var thisProp in PropList) {
      ...
    }
 
