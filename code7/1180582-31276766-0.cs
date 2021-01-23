    // IPlugin.cs
    [InheritedExport]
    public interface IPlugin
    {
        bool Check_When_Loaded(string q);
    }
