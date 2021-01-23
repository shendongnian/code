    private static bool HasGui(Assembly a)
    {
        return a.DefinedTypes
            .Any(t => typeof(System.Windows.Forms.Form).IsAssignableFrom(t) ||
                      typeof(System.Windows.Window).IsAssignableFrom(t));
    }
