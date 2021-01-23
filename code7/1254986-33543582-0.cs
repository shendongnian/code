    object set = new DbSet<MyClass>();
    var conv = set.GetType().GetMethod("op_Implicit", BindingFlags.Static | BindingFlags.Public, null, new[] { set.GetType() }, null);
    if (conv != null && conv.ReturnType == typeof(DbSet))
    {
        var rawSet = (DbSet)conv.Invoke(null, new object[] { set });
    }
