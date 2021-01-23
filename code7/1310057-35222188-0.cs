    var controllers= myControllerList
    .Where(type =>type.Namespace.StartsWith("X."))
    .SelectMany(type => type.GetMethods())
    .Select(m =>  new {
       Type = m.DeclaringType, 
       Att = m.GetCustomAttribute(typeof(MyAttribute)) as MyAttribute
    })
    .Where(t=>t.Att!=null)
    .Select(t=> new
        {
            Namespace = GetPath(t.Type.Namespace),
            ActionName= t.Att.Name,
            Controller = t.Type.Name.Remove(2);
        }
    ).ToList();
