    private List<string> _stringNames;
    private IEnumerable<int> GetIdentifiers(string contains)
    {
        if (_stringNames == null)
        {
            var eass = Assembly.GetExecutingAssembly();
            Func<Assembly, Type> f = ass =>
                ass.GetCustomAttributes(typeof(ResourceDesignerAttribute), true)
                    .OfType<ResourceDesignerAttribute>()
                    .Where(ca => ca.IsApplication)
                    .Select(ca => ass.GetType(ca.FullName))
                    .FirstOrDefault(ty => ty != null);
    
            var t = f(eass) ??
                AppDomain.CurrentDomain.GetAssemblies().Select(ass => f(ass)).FirstOrDefault(ty => ty != null);
    
            if (t != null)
            {
                var strings = t.GetNestedTypes().FirstOrDefault(n => n.Name == "String");
    
                if (strings != null)
                {
                    var fields = strings.GetFields();
                    _stringNames = new List<string>();
                    foreach (var field in fields)
                    {
                        _stringNames.Add(field.Name);
                    }
                }
            }
        }
    
        if (_stringNames != null)
        {
            var names = _stringNames.Where(s => s.Contains(contains));
            foreach (var name in names)
            {
                yield return Resources.GetIdentifier(name, "string", ComponentName.PackageName);
            }
        }
    }
