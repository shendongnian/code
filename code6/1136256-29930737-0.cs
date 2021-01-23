    PropertyInfo pInfo = ViewBag.GetType().GetProperty("ViewData",
    System.Reflection.BindingFlags.Public |
    System.Reflection.BindingFlags.NonPublic |
    System.Reflection.BindingFlags.Instance);
    var viewDataDictionary = pInfo.GetValue(ViewBag, null);
