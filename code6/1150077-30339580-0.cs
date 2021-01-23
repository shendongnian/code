    private void VisitJObject(JObject jObject)
    {
        foreach (var property in jObject.Properties())
        {
            EnterContext(property.Name);
            VisitProperty(property);
            ExitContext();
        }
    }
    private void EnterContext(string context)
    {
        _context.Push(context);
        _currentPath = string.Join(":", _context.Reverse());
    }
    private void ExitContext()
    {
        _context.Pop();
        _currentPath = string.Join(":", _context.Reverse());
    }
