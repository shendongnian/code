    var query = types.GetType()
        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(p => p.GetIndexParameters().Length == 0 && p.GetGetMethod() != null && p.CanRead)
        .Select(p => new Row { c = new List<C> { new C { v = p.Name }, new C { v = p.GetValue(types, new object[0]) } } });
    var root = new Rootobject
    {
        cols = new List<Names> { new Names { label = "Types", type = "string" }, new Names { label = "values", type = "number" } },
        rows = query.ToList(),
    };
    return Json(root, JsonRequestBehavior.AllowGet);
