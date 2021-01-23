    // IPlugin.cs
    using System.ComponentModel.Composition;
    [InheritedExport]
    public interface IPlugin
    {
        bool Check_When_Loaded(string q);
    }
