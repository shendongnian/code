    public interface CommonPluginInterface
    {
        string GetPluginName();
        bool ElaborateReport();
        ePluginType PluginType { get; }
    }
