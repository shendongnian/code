    internal void Serialize(object o)
    {
        var caller = new StackFrame(1, true).GetMethod().Name;
        string file = string.Format(_basePath, caller);
        if (File.Exists(file))  File.Delete(file);
        JsonHelpers.Save(file, o);
    }
